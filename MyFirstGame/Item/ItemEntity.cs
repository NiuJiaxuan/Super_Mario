using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Block.State;
using Sprint0.Item.State;
using Sprint0.Mario;
using Sprint0.Sprites;
using Sprint0.Sprites.factory;
using System;
using System.Collections.Generic;

namespace Sprint0.Item
{
    public class ItemEntity : Entity
    {

        public virtual ItemFactory ItemFactory => game.ItemFactory;
        public bool isVisible = true;
        public enum eItemType
        {
            Coin = 0,
            SuperMushroom = 1,
            FireFlower = 2,
            OneUpMushroom = 3,
            Star = 4,
            Pipe = 5,
        }
        public IItemState CurrentState { get; set; }
        public eItemType ItemType { get; set; }

        public ItemEntity(Game1 game, Vector2 position)
            : base(game, position)
        {
        }

        public override void Update(GameTime gameTime, List<Entity> entities, MarioEntity mario)
        {
            base.Update(gameTime,entities, mario);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible) {  
            base.Draw(spriteBatch);
            }
        }

        public void changeToVisible()
        {
            isVisible = true;
        }

        public void BumpTransition()
        {
            CurrentState?.BumpTransition();
        }
    }
}
