using Microsoft.Xna.Framework;
using Sprint0.Mario.MarioMotionState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Mario.MarioPowerState
{
    public abstract class MarioPowerState : IMarioPowerState
    {
        protected IMarioPowerState previousState;

        public MarioEntity Mario { get; set; }
        protected IMarioPowerState CurrentState { get { return Mario.currentPowerState; }set { Mario.currentPowerState = value; } }

        IMarioPowerState IMarioPowerState.PreviousState { get { return previousState;} }

        protected IMarioMotionState CurrentMotionState { get { return Mario.currentMotionState; } }

        protected MarioPowerState(MarioEntity mario)
        {
            Mario = mario;

        }

        public virtual void Enter(IMarioPowerState powerState)
        {
            CurrentState = this;
            this.previousState = powerState;
        }

        public virtual void Exit() { }
        public virtual void NormalTransion() { }
        public virtual void FireTransion() { }
        public virtual void SuperTransion() { }
        public virtual void DeadTransion() { }
        public virtual void Update(GameTime gameTime) { }

    }
}
