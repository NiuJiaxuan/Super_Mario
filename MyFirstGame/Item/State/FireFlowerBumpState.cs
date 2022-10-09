using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Item.State
{
    class FireFlowerBumpState : ItemStates
    {
        Vector2 Origion;

        public FireFlowerBumpState(ItemEntity item)
            : base(item)
        {
        }
        public override void Enter(IItemState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
            Origion = Item.Position;

            Item.Speed = new Vector2(0, -40);
        }
        public override void Exit()
        {
            Item.Position = Origion;
            Item.Speed = new Vector2(0, 0);
        }

        public override void NormalTransition()
        {
            CurrentState.Exit();
            CurrentState = new FireFlowerNormalState(Item);
            CurrentState.Enter(this);
        }

        public override void Update(GameTime gameTime)
        {
            if (Math.Abs(Item.Position.Y - Origion.Y) > 10)
                Item.Speed = new Vector2(0, Item.Speed.Y * -1);
            else if (Math.Abs(Item.Position.Y - Origion.Y) == 0)
                NormalTransition();
        }

    }
}
