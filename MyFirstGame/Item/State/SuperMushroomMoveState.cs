using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Mario;
using Sprint0.Sprites;
using Sprint0.Sprites.factory;
using Sprint0.Mario.MarioMotionState;
using Sprint0.Mario.MarioPowerState;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Item.State
{
    public class SuperMushroomMoveState : ItemStates
    {

        Vector2 Origion;

        public SuperMushroomMoveState(ItemEntity item)
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
            Item.Speed = new Vector2(0, 0);
        }
        public override void BumpTransition()
        {
            CurrentState.Exit();
            CurrentState = new SuperMushroomBumpState(Item);
            CurrentState.Enter(this);
        }
        public override void NormalTransition()
        {
            CurrentState.Exit();
            CurrentState = new SuperMushroomNormalState(Item);
            CurrentState.Enter(this);
        }
        public override void Update(GameTime gameTime)
        {
            /*if ((Item.Position.X - Mario.Position.X)> 0)
            {
                Item.Speed = new Vector2(-70, 0);
            }else if ((Item.Position.X - Mario.Position.X) < 0)
            {
                Item.Speed = new Vector2(70, 0);
            }*/
        }
    }
}
