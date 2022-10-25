using Sprint0.Block.State;
using Sprint0.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Sprint0.Sprites.factory;

namespace Sprint0.Item.State
{
    class FireballMovingState : ItemStates
    {
        public FireballMovingState(ItemEntity item)
           : base(item)
        {
        }

        public override void Enter(IItemState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;

            Vector2 Origion = Vector2.Zero;
            if (Item.Sprite != null)
            {
                Origion = Item.Position;
            }

            Item.Sprite = Item.ItemFactory.CreateItem(Item.game, Item.Position, (int)ItemSpriteFactory.eItemType.Coin);
            Item.ItemType = ItemEntity.eItemType.Coin;
            Item.Position = Origion;
        }

        public override void BumpTransition()
        {
            CurrentState.Exit();
            CurrentState = new CoinBumpState(Item);
            CurrentState.Enter(this);
        }
    }
}
