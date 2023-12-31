﻿using Sprint0.State;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Sprint0.Block.State
{
    class QuestionBlockBumpState : BlockStates
    {
        Vector2 Origion;
        int Count;


        public QuestionBlockBumpState(BlockEntity block, int count)
            : base(block)
        {
            Count = count;
            Block.isBumping = true;
        }

        public override void Enter(IBlockState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
            Origion = Block.Position;

            Block.Speed = new Vector2(0, -40);
        }
        public override void Exit()
        {
            Block.Position = Origion;
            Block.isBumping = false;
            Block.Speed = new Vector2(0, 0);
        }
        public override void NormalTransition()
        {
            CurrentState.Exit();
            if (Count != 0)
            {
                CurrentState = new QuestionBlockNormalState(Block);
            }
            else
            {
                CurrentState = new UsedBlockNormalState(Block);
            }
            CurrentState.Enter(this);
        }
        public override void Update(GameTime gameTime)
        {
            if (Math.Abs(Block.Position.Y - Origion.Y) > 10)
                Block.Speed = new Vector2(0, Block.Speed.Y * -1);
            else if (Math.Abs(Block.Position.Y - Origion.Y) == 0)
                NormalTransition();
        }
    }
}
