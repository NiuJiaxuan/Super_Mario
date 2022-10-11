using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Block.State;
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

        public ItemEntity item;

        public BrickBlockEntity(Game1 game, Vector2 position, bool isVisible, BlockItemType blockItemType)
            : base(game, position)
        {
            Sprite = BlockFactory.CreateBlock(game,position, (int)eBlockType.BrickBlock);
            if ((int)blockItemType != 6)
                item = new ItemEntity(game, position,false, blockItemType);
            BlockType = eBlockType.BrickBlock;
            CurrentState = new BrickBlockNormalState(this);
            CurrentState.Enter(null);
            IsVisible = isVisible;
        }

        public override void Update(GameTime gameTime, MarioEntity mario, List<Entity> enemyEntities)
        {
            Mario = mario;
            item.Update(gameTime, entities, mario);
            base.Update(gameTime,entities, mario);

        }
        public override void Draw(SpriteBatch spriteBatch)
        {        
            item.Draw(spriteBatch);
             base.Draw(spriteBatch);
            
        }
        public void ChangeToVisible()
        {
            IsVisible = true;
        }

        public void BumpOrBreakTransition()
        {
            switch (Mario.currentPowerState)
            {
                case SuperState:
                    CurrentState?.BreakTransition();
                    break;
                case FireState:
                    CurrentState?.BreakTransition();
                    break;
                default:
                    BumpTransition();
                    break;
            }
        }
    }
}
