using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Block.State;
using Sprint0.Mario;
using Sprint0.Mario.MarioMotionState;
using Sprint0.Mario.MarioPowerState;
using Sprint0.Sprites;
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

        public IBlockState CurrentState { get; set; }
        public eBlockType BlockType { get; set; }
        public MarioEntity Mario { get; set; }

        public virtual BlockFactory BlockFactory => game.BlockFactory;


        public enum eBlockType
        {
            QuestionBlock = 1,
            BrickBlock = 2,
            FloorBlock = 3,
            StairBlock = 4,
            SmallBrickBlock = 5,
        }

        public int generateType(IBlockState blockState)
        {
            int type = 0;
            switch (blockState)
            {
                case IdleState:
                    type = 1;
                    break;
                case WalkState:
                    type = 2;
                    break;
                case JumpState:
                    type = 3;
                    break;
                case CrouchState:
                    type = 4;
                    break;
            }
            Debug.WriteLine(type);

            return type;
        }

        public BlockEntity(Game1 game, Vector2 position) : base(game, position)
        {

        }
        public int blockType { get; set; }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Speed += Accelation * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            CurrentState?.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public void BumpTransition()
        {
            CurrentState?.BumpTransition();
        }

        public void BreakTransition()
        {
            switch (Mario.currentPowerState)
            {
                case SuperState:
                    
                    break;
                case FireState:

                    break;
                default:

                    break;
            }
        }
    }
}
