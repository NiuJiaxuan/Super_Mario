using Microsoft.Xna.Framework;
using Sprint0.Block;
using Sprint0.Command;
using Sprint0.Mario;
using Sprint0.Mario.MarioMotionState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Sprint0.Block.State;
using Sprint0.State;

namespace Sprint0.State
{
    public abstract class BlockStates : IBlockState
    {
        protected IBlockState previousState;
        public BlockEntity Block { get; protected set; }
        protected IBlockState CurrentState { get { return Block.CurrentState; } set { Block.CurrentState = value; } }
        IBlockState IBlockState.PreviousState { get { return previousState; } }

        public virtual void Enter(IBlockState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
        }

        protected BlockStates(BlockEntity block)
        {
            Block = block;
        }

        public virtual void Exit() { }
        public virtual void NormalTransition() { }
        public virtual void BumpTransition() { }
        public virtual void UsedTransition() { }

        public virtual void BreakTransition() { }

        public virtual void Update(GameTime gameTime) { }


    }
}
