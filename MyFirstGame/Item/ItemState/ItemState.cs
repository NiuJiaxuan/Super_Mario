using Microsoft.Xna.Framework;

using Sprint0.Item.State;
using Sprint0.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Item.ItemState
{
    public abstract class ItemState : IItemState
    {
        IItemState previousState;
        IItemState IItemState.PreviousState
        {
            get { return previousState; }
            //set { previousState = value; }
        }

        public ItemEntity Item { get; protected set; }

        protected IItemState CurrentState
        {
            get { return Item.CurrentState; }
            set { Item.CurrentState = value; }
        }

        public virtual void Enter(IItemState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
        }

        public virtual void Exit() { }
        public virtual void NormalTransition() { }
        public virtual void BumpTransition() { }
        public virtual void MovingTransition() { }

      

        public virtual void Update(GameTime gameTime) { }


    }
}
