using Microsoft.Xna.Framework;
using Sprint0.Sprites.factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Item.State
{
    class SuperMushroomNormalState : ItemStates
    {
        public SuperMushroomNormalState(ItemEntity item)
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

            Item.Sprite = Item.ItemFactory.CreateItem(Item.game, Item.Position, (int)ItemSpriteFactory.eItemType.SuperMushroom);
            Item.ItemType = ItemEntity.eItemType.SuperMushroom;
            Item.Position = Origion;
        }

        public override void BumpTransition()
        {
            CurrentState.Exit();
            CurrentState = new SuperMushroomBumpState(Item);
            CurrentState.Enter(this);
        }
    }
}
