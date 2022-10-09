using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.factory;
using Sprint0.State;

namespace Sprint0.Item.State
{
    class FireFlowerNormalState : ItemStates
    {
            public FireFlowerNormalState(ItemEntity item)
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

                Item.Sprite = Item.ItemFactory.CreateItem(Item.game, Item.Position, (int)ItemSpriteFactory.eItemType.FireFlower);
                Item.ItemType = ItemEntity.eItemType.FireFlower;
                Item.Position = Origion;
            }

            public override void BumpTransition()
            {
                CurrentState.Exit();
                CurrentState = new FireFlowerBumpState(Item);
                CurrentState.Enter(this);
            }
        }
    }

