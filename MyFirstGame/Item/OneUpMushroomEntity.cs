using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Sprites;
using static Sprint0.State.BlockEntity;

namespace Sprint0.Item
{
    public class OneUpMushroomEntity : ItemEntity
    {
        public OneUpMushroomEntity(Game1 game, Vector2 position)
            : base(game, position)
        {
            ItemType = eItemType.OneUpMushroom;
            Sprite = ItemFactory.CreateItem(game, position, (int)ItemType);
        }

        public override void Update(GameTime gameTime, List<Entity> entities)
        {
            base.Update(gameTime,entities);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }


    }
}
