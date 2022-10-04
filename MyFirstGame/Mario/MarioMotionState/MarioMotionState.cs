using Microsoft.Xna.Framework;
using Sprint0.interfaces;
using Sprint0.Mario.MarioPowerState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Mario.MarioMotionState
{
    public abstract class MarioMotionState : IMarioMotionState
    {
        protected IMarioMotionState previousState;

        protected IMarioPowerState PowerState { get { return Mario.currentPowerState; } }

        public MarioEntity Mario;

        protected IMarioMotionState CurrentState { get { return Mario.currentMotionState; } set { Mario.currentMotionState = value; } }
        IMarioMotionState IMarioMotionState.PreviousState { get { return previousState; } }

        protected MarioMotionState(MarioEntity mario)
        {
            Mario = mario;
        }

        public virtual void Enter(IMarioMotionState state)
        {
            CurrentState = this;
            this.previousState = state;
        }

        public virtual void Exit() { }

        public virtual void JumpTransion() { }
        public virtual void WalkTransion() { }
        public virtual void IdleTransion() { }
        public virtual void CrouchTransion() { }

        public virtual void Update(GameTime gameTime) { }

    }
}
