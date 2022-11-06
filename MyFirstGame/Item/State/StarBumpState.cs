using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Item.State
{
    class StarBumpState : ItemStates
    {
        Vector2 Origion;

        public StarBumpState(ItemEntity item)
            : base(item)
        {
        }
        public override void Enter(IItemState previousState)
        {
            SoundStorage.Instance.PlayPowerUpAppear();
            CurrentState = this;
            this.previousState = previousState;
            Origion = Item.Position;

            Item.Speed = new Vector2(0, -40);
        }

        public override void Exit()
        {
            Item.Speed = new Vector2(0, 0);
        }

        public override void MovingTransition()
        {
            CurrentState.Exit();
            CurrentState = new StarMoveState(Item);
            CurrentState.Enter(this);
        }
        public override void Update(GameTime gameTime)
        {
            if (Math.Abs(Item.Position.Y - Origion.Y) > 30) { 
                MovingTransition();
            }
            //CurrentState = new StarMoveState(Item);

        }
    }
}
