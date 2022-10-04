﻿using Microsoft.Xna.Framework;
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
            type = Mario.generateType(CurrentState, PowerState);

            Mario.Sprite = Mario.MarioFactory.CreateMario(Mario.game, Mario.Position, type);
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
        }
    }
}
