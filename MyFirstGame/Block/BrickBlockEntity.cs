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
        public List<Entity> ItemEntityList;

        public BrickBlockEntity(Game1 game, Vector2 position, bool isVisible, List<ItemEntity> blockItemList, List<Entity> itemEntityList)
            : base(game, position)
        {
            Sprite = BlockFactory.CreateBlock(game,position, (int)eBlockType.BrickBlock);
            BlockType = eBlockType.BrickBlock;
            CurrentState = new BrickBlockNormalState(this);
            CurrentState.Enter(null);
            IsVisible = isVisible;

            BlockItemList = blockItemList;
            ItemEntityList = itemEntityList;
        }

        public override void CollisionResponse(Entity entity, Vector2 position, CollisionDetector.Touching touching)
        {
            switch (entity)
            {
                case MarioEntity:
                    if (touching == CollisionDetector.Touching.bottom)
                    {
                        BumpOrBreakTransition();
                        switch (Mario.currentPowerState)
                        {
                            case SuperState:
                                foreach (ItemEntity item in BlockItemList)
                                {
                                    ItemEntityList.Add(item);
                                    item.BumpTransition();
                                }
                                BlockItemList.Clear();
                                break;
                            case FireState:
                                foreach (ItemEntity item in BlockItemList)
                                {
                                    ItemEntityList.Add(item);
                                    item.BumpTransition();
                                }
                                BlockItemList.Clear();
                                break;
                            default:
                                if (BlockItemList.Count != 0)
                                {
                                    ItemEntity temp = BlockItemList.First();
                                    ItemEntityList.Add(temp);
                                    temp.BumpTransition();
                                    BlockItemList.Remove(temp);

                                }
                                break;
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
