using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Block.BlockState;
using Sprint0.Mario;
using Sprint0.Mario.MarioPowerState;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Sprint0.Block
{
    public class BlockEntity : Entity
    {

        public IBlockState CurrentState { get; set; }
        public MarioEntity Mario { get; set; }

        public BlockEntity(Game1 game, Vector2 position) : base(game, position)
        {
        }

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

        BreakTransition
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
