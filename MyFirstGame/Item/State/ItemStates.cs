using Sprint0.Item.State;
using Sprint0.State;
using Sprint0.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Mario;
using Sprint0.Sprites;
using Sprint0.Sprites.factory;

namespace Sprint0.Item.State
{
    public abstract class ItemStates : IItemState
    {
        protected IItemState previousState;
        public ItemEntity Item { get; protected set; }
        protected IItemState CurrentState { get { return Item.CurrentState; } set { Item.CurrentState = value; } }
        IItemState IItemState.PreviousState { get { return previousState; } }


        public virtual void Enter(IItemState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
        }

        protected ItemStates(ItemEntity item)
        {
            Item = item;
        }

        public virtual void Exit() { }
        public virtual void NormalTransition() { }
        public virtual void BumpTransition() { }
        public virtual void MovingTransition() { }

        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(SpriteBatch batch) { }
    }
}
