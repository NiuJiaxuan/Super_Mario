using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Block.State;
using Sprint0.Item.State;
using Sprint0.Mario;
using Sprint0.Sprites;
using Sprint0.Sprites.factory;
using System;
using System.Collections.Generic;
using static Sprint0.State.BlockEntity;

namespace Sprint0.Item
{
    public class ItemEntity : Entity
    {

        public virtual ItemFactory ItemFactory => game.ItemFactory;
        public enum eItemType
        {
            Coin = 0,
            SuperMushroom = 1,
            FireFlower = 2,
            OneUpMushroom = 3,
            Star = 4,
            Pipe = 5,
            None = 6,
        }
        public IItemState CurrentState { get; set; }
        public eItemType ItemType { get; set; }

        public ItemEntity(Game1 game, Vector2 position, bool isVisible, BlockItemType itemType)
            : base(game, position)
        {
            Sprite = ItemFactory.CreateItem(game, position, (int)itemType);
            Sprite.Speed = new Vector2(0, -60);
            IsVisible = isVisible;
        }

        public ItemEntity(Game1 game, Vector2 position)
            : base(game, position)
        {
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsVisible) {  
                base.Draw(spriteBatch);
            }
        }

        public void changeToVisible()
        {
            IsVisible = true;
        }

        public void BumpTransition()
        {
            CurrentState?.BumpTransition();
        }
    }
}
