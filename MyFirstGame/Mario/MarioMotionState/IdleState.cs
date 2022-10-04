using Microsoft.Xna.Framework;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Mario.MarioMotionState
{
    public class IdleState : MarioMotionState
    {
        private int type;

        public IdleState(MarioEntity mario)
            : base(mario)
        {

        }

        public override void Enter(IMarioMotionState state)
        {
            CurrentState = this;
            this.previousState = state;
            powerState = Mario.currentPowerState;
            type = Mario.generateType(CurrentState, powerState);   
            
            Mario.Sprite = MarioFactory.
        }

        public override void IdleTransion()
        {
            base.IdleTransion();
        }
        public override void JumpTransion()
        {
            base.JumpTransion();
        }
        public override void CrouchTransion()
        {
            base.CrouchTransion();
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
