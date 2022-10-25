using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Item.State
{
    public class OneUpMushroomMoveState : ItemStates
    {

        Vector2 Origion;

        public OneUpMushroomMoveState(ItemEntity item)
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
            CurrentState = new OneUpMushroomBumpState(Item);
            CurrentState.Enter(this);
        }
        public override void NormalTransition()
        {
            CurrentState.Exit();
            CurrentState = new OneUpMushroomNormalState(Item);
            CurrentState.Enter(this);
        }
        public override void Update(GameTime gameTime)
        {
            if ((Item.Position.X - EntityStorage.Instance.Mario.Position.X)> 0)
            {
                Item.Speed = new Vector2(40,0);
            }else if ((Item.Position.X - EntityStorage.Instance.Mario.Position.X) < 0)
            {
                Item.Speed = new Vector2(-40, 0);
            }
        }
    }
}
