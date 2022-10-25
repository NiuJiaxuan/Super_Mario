using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Item.State
{
    public class StarMoveState : ItemStates
    {

        Vector2 Origion;

        public StarMoveState(ItemEntity item)
            : base(item)
        {
        }


        public override void Enter(IItemState previousState)
        {
            EntityStorage.Instance.MovableEntities.Add(Item);
            CurrentState = this;
            this.previousState = previousState;

            Origion = Item.Position;

            Item.Speed = new Vector2(0, -40);
        }

        public override void Exit()
        {
            Item.Speed = new Vector2(0, 0);
        }
        public override void BumpTransition()
        {
            CurrentState.Exit();
            CurrentState = new StarBumpState(Item);
            CurrentState.Enter(this);
        }
        public override void NormalTransition()
        {
            CurrentState.Exit();
            CurrentState = new StarNormalState(Item);
            CurrentState.Enter(this);
        }
        public override void Update(GameTime gameTime)
        {
            if ((Item.Position.X - EntityStorage.Instance.Mario.Position.X)> 0)
            {
                Item.Speed = new Vector2(40, -10);
                this.Origion = Item.Position;
                if (Math.Abs(Item.Position.Y - Origion.Y) > 10)
                {
                    Item.Speed = new Vector2(0, -Item.Speed.Y);
                }
            }
            else if ((Item.Position.X - EntityStorage.Instance.Mario.Position.X) < 0)
            {
                Item.Speed = new Vector2(-40, -10);
                this.Origion = Item.Position;
                if (Math.Abs(Item.Position.Y - Origion.Y) > 10)
                {
                    Item.Speed = new Vector2(0, -Item.Speed.Y);
                }
            }
            
        }
    }
}
