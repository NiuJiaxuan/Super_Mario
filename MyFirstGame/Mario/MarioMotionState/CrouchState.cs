using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Mario.MarioMotionState
{
    public class CrouchState : MarioMotionState
    {
        public CrouchState(MarioEntity mario)
            : base(mario)
        {

        }

        public override void Enter(IMarioMotionState state)
        {
            CurrentState = this;
            this.previousState = state;

            SpriteEffects facing = Mario.Sprite.Orientation;
            int type = Mario.generateType(CurrentState, PowerState);
            Mario.Sprite = Mario.MarioFactory.CreateMario(Mario.game, Mario.Position, type);
            Mario.Sprite.Orientation = facing;
            Mario.marioType = type;
        }

        public override void WalkTransion()
        {
            CurrentState.Exit();
            CurrentState = new WalkState(Mario);
            CurrentState.Enter(this);
        }
        public override void JumpTransion()
        {
            CurrentState.Exit();
            CurrentState = new JumpState(Mario);
            CurrentState.Enter(this);
        }
        public override void IdleTransion()
        {
            CurrentState.Exit();
            CurrentState = new IdleState(Mario);
            CurrentState.Enter(this);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update(GameTime gameTime)
        {
            Mario.Speed = new Vector2(Mario.Speed.X, 70);
            base.Update(gameTime);

            if (Mario.Sprite.Position.Y > 480)
            {
               Mario.Speed = new Vector2(Mario.Speed.X, 0);
                Mario.Position = new Vector2(Mario.Position.X, 480);
            }
        }
    }
}
