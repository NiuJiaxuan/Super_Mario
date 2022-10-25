using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Sprites;
using Sprint0.Item.State;
using Sprint0.Mario;
using Sprint0.Mario.MarioMotionState;
using Sprint0.Sprites.factory;

namespace Sprint0.Item
{
    public class SuperMushroomEntity : ItemEntity
    {
        public SuperMushroomEntity(Game1 game, Vector2 position)
            : base(game, position)
        {
            ItemType = eItemType.SuperMushroom;
            Sprite = ItemFactory.CreateItem(game, position, (int)ItemType);
            CurrentState = new SuperMushroomNormalState(this);
            CurrentState.Enter(null);

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

       

    }
}
