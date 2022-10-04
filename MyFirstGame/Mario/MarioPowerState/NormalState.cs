using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Mario.MarioPowerState
{
    public class NormalState : MarioPowerState
    {

        public NormalState(MarioEntity mario) 
            : base(mario)
        {
        }

        public override void Enter(IMarioPowerState powerState)
        {
            CurrentState = this;
            this.previousState = powerState;

            int type = Mario.generateType(CurrentMotionState, CurrentState);
            Mario.Sprite = Mario.MarioFactory.CreateMario(Mario.game, Mario.Position, type);
            Mario.marioType = type;
        }

        public override void DeadTransion()
        {
            CurrentState.Exit();
            CurrentState = new DeadState(Mario);
            CurrentState.Enter(this);

        }
        public override void FireTransion()
        {
            CurrentState.Exit();
            CurrentState = new FireState(Mario);
            CurrentState.Enter(this);
        }
        public override void SuperTransion()
        {
            CurrentState.Exit();
            CurrentState = new SuperState(Mario);
            CurrentState.Enter(this);
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
