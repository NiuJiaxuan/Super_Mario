using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Mario.MarioPowerState
{
    public class SuperState : MarioPowerState
    {

        Vector2 anchor;
        public SuperState(MarioEntity mario)
            : base(mario)
        {
        }

        public override void Enter(IMarioPowerState powerState)
        {
            CurrentState = this;
            this.previousState = powerState;
            anchor.X += Mario.Sprite.FrameSize.X;

            int type = Mario.generateType(CurrentMotionState, CurrentState);
            Mario.Sprite = Mario.MarioFactory.CreateMario(Mario.game, Mario.Position, type);
            Mario.marioType = type;
        }

        public override void NormalTransion()
        {
            CurrentState.Exit();
            CurrentState = new NormalState(Mario);
            CurrentState.Enter(this);
        }
        public override void FireTransion()
        {
            CurrentState.Exit();
            CurrentState = new FireState(Mario);
            CurrentState.Enter(this);
        }
        public override void DeadTransion()
        {
            CurrentState.Exit();
            CurrentState = new DeadState(Mario);
            CurrentState.Enter(this);
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
