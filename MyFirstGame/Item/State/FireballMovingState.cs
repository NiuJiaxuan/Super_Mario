using Sprint0.Block.State;
using Sprint0.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
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

            Item.Sprite = Item.ItemFactory.CreateItem(Item.game, Item.Position, (int)ItemSpriteFactory.eItemType.Fireball);
            Item.ItemType = ItemEntity.eItemType.Fireball;

            if(EntityStorage.Instance.Mario.Orientation == SpriteEffects.None)
                Item.Speed = new Vector2(140, 0);
            else
                Item.Speed = new Vector2(-140,0);
        }

        public override void BouncingTransition()
        {
            CurrentState.Exit();
            CurrentState = new FireballBouncingState(Item);
            CurrentState.Enter(this);
        }
    }
}
