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
    public class WalkState : MarioMotionState
    {
        public WalkState(MarioEntity mario)
            : base(mario)
        {

        }

        public override void Enter(IMarioMotionState state)
        {
            CurrentState = this;
            this.previousState = state;

            SpriteEffects facing = Mario.Sprite.Orientation;
            int type = Mario.generateType(CurrentState, PowerState);
            Mario.Sprite = Mario.MarioFactory.CreateMario(Mario.game,Mario.Position, type);
            Mario.Sprite.Orientation = facing;
            Mario.marioType = type;

        }

        public override void IdleTransion()
        {
            CurrentState.Exit();
            CurrentState = new IdleState(Mario);
            CurrentState.Enter(this);
        }
        public override void JumpTransion()
        {
            CurrentState.Exit();
            CurrentState = new JumpState(Mario);
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
            if (Mario.Sprite.Orientation == SpriteEffects.None)
            {
                Mario.Speed = new Vector2(70, Mario.Speed.Y);
            }
            else if(Mario.Sprite.Orientation == SpriteEffects.FlipHorizontally)
            {
                Mario.Speed = new Vector2(-70, Mario.Speed.Y);
            }
            //Debug.WriteLine(Mario.Speed);
            base.Update(gameTime);
        }
    }
}
