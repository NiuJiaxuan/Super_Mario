﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Block.State;
using Sprint0.CollisionDetection;
using Sprint0.Item;
using Sprint0.Mario;
using Sprint0.Sprites;
using Sprint0.Sprites.factory;
using Sprint0.State;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Block
{
    public class QuestionBlockEntity : BlockEntity
    {

        public List<ItemEntity> BlockItemList;
        public List<Entity> ItemEntityList;

        public QuestionBlockEntity(Game1 game, Vector2 position, bool isVisible, List<ItemEntity> blockItemList, List<Entity> itemEntityList)
            : base(game, position)
        {
            Sprite = BlockFactory.CreateBlock(game, position, (int)eBlockType.QuestionBlock);
            BlockType = eBlockType.QuestionBlock;
            CurrentState = new QuestionBlockNormalState(this);
            CurrentState.Enter(null);
            IsVisible = isVisible;

            BlockItemList = blockItemList;
            ItemEntityList = itemEntityList;
        }

        public void marioCollsionDetection(MarioEntity mario)
        {
            List<Entity> entities = new List<Entity>();
            entities.Add(mario);
            Tuple<Collision.Touching, float, float, Entity> detected = collisionDetection.detectCollsion(entities);

            if (detected.Item1 == Collision.Touching.bottom)
            {
                if (!IsVisible)
                {
                    ChangeToVisible();

                }
                else
                {
                    if (BlockItemList.Count != 0)
                    {
                        BumpTransition();
                        ItemEntity temp = BlockItemList[0];
                        ItemEntityList.Add(temp);
                        temp.BumpTransition();
                        BlockItemList.RemoveAt(0);
                    }
                    else
                    {
                        Sprite = BlockFactory.CreateBlock(game, Position, (int)eBlockType.UsedBlock);
                    }

                }
            }

        }

        public override void Update(GameTime gameTime, MarioEntity mario, List<Entity> enemyEntities, List<Entity> blockEntities)
        {
            marioCollsionDetection(mario);
            base.Update(gameTime, mario, enemyEntities, blockEntities);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            
            base.Draw(spriteBatch);
            
        }
    }
}
