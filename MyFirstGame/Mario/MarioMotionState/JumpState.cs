using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
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

        }

        public override void IdleToWalk()
        {
            base.IdleToWalk();
        }

        public override void IdleToJump()
        {
            base.IdleToJump();
        }

        public override void IdleToCrouch()
        {
            base.IdleToCrouch();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
