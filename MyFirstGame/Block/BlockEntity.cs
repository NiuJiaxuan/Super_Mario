using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Block;
using Sprint0.Block.State;
using Sprint0.CollisionDetection;
using Sprint0.Enemy;
using Sprint0.Item;
using Sprint0.Mario;
using Sprint0.Mario.MarioMotionState;
using Sprint0.Mario.MarioPowerState;
using Sprint0.Sprites;
using Sprint0.Sprites.factory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Sprint0.State
{
    public class BlockEntity : Entity
    {
        private Sprite smallBlock1;
        private Sprite smallBlock2;
        private Sprite smallBlock3;
        private Sprite smallBlock4;

        public IBlockState CurrentState { get; set; }
        public eBlockType BlockType { get; set; }

        public virtual BlockFactory BlockFactory => game.BlockFactory;

        public bool breakBlockVisible = true;
        public bool isBumping = false;

        public override Rectangle GetRectangle
        {
            get
            {
                if (!IsVisible)
                {
                    if (EntityStorage.Instance.Mario.Position.Y < this.Position.Y+EntityStorage.Instance.Mario.Sprite.FrameSize.Y  && EntityStorage.Instance.Mario.Speed.Y>=0)
                        return new Rectangle();
                    else
                        return base.GetRectangle;
                }
                else
                {
                    return base.GetRectangle;
                }
            }
        }

        public Sprite SmallBlock1
        {
            get { return smallBlock1; }
            set { smallBlock1 = value; }
        }
        public Sprite SmallBlock2
        {
            get { return smallBlock2; }
            set { smallBlock2 = value; }
        }
        public Sprite SmallBlock3
        {
            get { return smallBlock3; }
            set { smallBlock3 = value; }
        }
        public Sprite SmallBlock4
        {
            get { return smallBlock4; }
            set { smallBlock4 = value; }
        }
        public enum eBlockType
        {
            QuestionBlock = 1,
            BrickBlock = 2,
            FloorBlock = 3,
            StairBlock = 4,
            UsedBlock = 5,
            SmallBrickBlock = 6,
        }

        public enum BlockItemType
        {
            Coin = 0,
            SuperMushroom = 1,
            FireFlower = 2,
            OneUpMushroom = 3,
            Star = 4,
            Pipe = 5,
            None = 6,
        }

        public BlockEntity(Game1 game, Vector2 position) : base(game, position)
        {
        }


        public override void Update(GameTime gameTime,List<Entity> entities)
        {
            base.Update(gameTime, entities);

            CurrentState?.Update(gameTime);            
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            if (breakBlockVisible)
            {
                base.Draw(spriteBatch);
            }
            
            
            SmallBlock1?.Draw(spriteBatch);
            SmallBlock2?.Draw(spriteBatch);
            SmallBlock3?.Draw(spriteBatch);
            SmallBlock4?.Draw(spriteBatch);
            
            
        }
        public void BumpTransition()
        {
            CurrentState?.BumpTransition();
        }

        public void BumpTransition(int count)
        {
            CurrentState?.BumpTransition(count);
        }

        public void ChangeToVisible()
        {
            IsVisible = true;
        }

        public void BumpOrBreakTransition(MarioEntity mario)
        {
            if (!IsVisible)
            {
                ChangeToVisible();
                BumpTransition();
            }
            else
            {
                switch (mario.currentPowerState)
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
}
