using Microsoft.Xna.Framework;
using Sprint0.Block.State;
using Sprint0.Command;
using Sprint0.Mario.MarioMotionState;
using Sprint0.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Block.BlockState
{
    public abstract class BlockState : IBlockState
    {
        IBlockState previousState;
        IBlockState IBlockState.PreviousState
        {
            get { return previousState; }
            set { previousState = value; }
        }

        public BlockEntity Block { get; protected set; }  

        protected IBlockState CurrentState
        {
            get { return Block.CurrentState; }
            set { Block.CurrentState = value; }
        }

        public virtual void Enter(IBlockState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
        }

        public virtual  void Exit() { }
        public virtual void NormalTransition() { }
        public virtual void BumpTransition() { }
        public virtual void UsedTransition() { }
        public virtual void BreakTransition() { }

        public virtual void Update(GameTime gameTime) { }


    }
}
