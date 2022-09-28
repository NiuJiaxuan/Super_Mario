using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Items
{
    public class FireFlower
    {
        ISprite fireFlowerSprite;
        public FireFlower(Game1 game, Vector2 position)
        {
            fireFlowerSprite = FireFlowerFactory.Instance.Create(game, position);
        }

        public void Update(GameTime gameTime)
        {
            fireFlowerSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch batch)
        {
            fireFlowerSprite.Draw(batch);
        }
    }
}
