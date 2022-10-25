using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Block.State;
using Sprint0.CollisionDetection;
using Sprint0.Enemy;
using Sprint0.Item;
using Sprint0.Mario;
using Sprint0.Mario.MarioPowerState;
using Sprint0.Sprites;
using Sprint0.State;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint0.State.BlockEntity;

namespace Sprint0.Block
{
    public class BrickBlockEntity : BlockEntity
    {
        public List<ItemEntity> BlockItemList;
        public List<Entity> EntityList;

        public BrickBlockEntity(Game1 game, Vector2 position, bool isVisible, List<ItemEntity> blockItemList, List<Entity> entityList)
            : base(game, position)
        {
            Sprite = BlockFactory.CreateBlock(game,position, (int)eBlockType.BrickBlock);
            BlockType = eBlockType.BrickBlock;
            CurrentState = new BrickBlockNormalState(this);
            CurrentState.Enter(null);
            IsVisible = isVisible;

            BlockItemList = blockItemList;
            EntityList = entityList;
        }

        public override void CollisionResponse(Entity entity, Vector2 position, CollisionDetector.Touching touching)
        {
            switch (entity)
            {
                case MarioEntity:
                    MarioEntity mario = (MarioEntity)entity;
                    if (touching == CollisionDetector.Touching.bottom)
                    {
                        BumpOrBreakTransition(mario);
                        switch (mario.currentPowerState)
                        {
                            case SuperState:
                                foreach (ItemEntity item in BlockItemList)
                                {
                                    
                                    item.BumpTransition();
                                }
                                BlockItemList.Clear();
                                break;
                            case FireState:
                                foreach (ItemEntity item in BlockItemList)
                                {
                                    
                                    item.BumpTransition();
                                }
                                BlockItemList.Clear();
                                break;
                            default:
                                if (BlockItemList.Count != 0)
                                {
                                    ItemEntity temp = BlockItemList.First();
                                    EntityList.Add(temp);
                                    temp.BumpTransition();
                                    BlockItemList.Remove(temp);

                                }
                                break;
                        }
                    }
                    else
                    {
                        if (!IsVisible)
                        {
                            EntityStorage.Instance.ColliableEntites.Remove(this);
                        }
                    }
                    break;
                case EnemyEntity:
                    Position = position;
                    break;
            }
        }

        public override void Update(GameTime gameTime,List<Entity> entities)
        {

            base.Update(gameTime, entities);

        }
        public override void Draw(SpriteBatch spriteBatch)
        {        
            base.Draw(spriteBatch);
            
        }

    }
}
