using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Mario.MarioMotionState
{
    public class JumpState : MarioMotionState
    {
        public JumpState(MarioEntity mario)
            : base(mario)
        {

        }

        public override void Enter(IMarioMotionState state)
        {
            CurrentState = this;
            this.previousState = state;

            Mario.onGround = false;
            Mario.Speed = new Vector2(Mario.Speed.X, -400);

            SpriteEffects facing = Mario.Sprite.Orientation;
            int type = Mario.generateType(CurrentState,PowerState);
            Mario.Sprite = Mario.MarioFactory.CreateMario(Mario.game,Mario.Position,type);
            Mario.Sprite.Orientation = facing;
            Mario.marioType = type;
        }

        public override void IdleTransion()
        {
            CurrentState.Exit();
            CurrentState = new IdleState(Mario);
            CurrentState.Enter(this);
        }

        public override void WalkTransion()
        {
            CurrentState.Exit();
            CurrentState = new WalkState(Mario);
            //Debug.WriteLine("walk transion " + Mario.Speed);

            CurrentState.Enter(this);
        }

        public override void FallTransion()
        {
            CurrentState.Exit();
            CurrentState = previousState;
            Mario.Speed = new Vector2(Mario.Speed.X, 0);
            CurrentState.Enter(this);
        }

        public override void CrouchTransion()
        {
            CurrentState.Exit();
            CurrentState = new CrouchState(Mario);
            CurrentState.Enter(this);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Mario.Sprite.Position.Y-Mario.Sprite.FrameSize.Y <0)
            {
                Mario.Speed = new Vector2(Mario.Speed.X, 0);
                Mario.Position = new Vector2(Mario.Position.X, Mario.Sprite.FrameSize.Y);
            }

        }
    }
}
