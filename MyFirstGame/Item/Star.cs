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
    public class Star
    {
        ISprite starSprite;
        public Star(Game1 game, Vector2 position)
        {
            starSprite = StarFactory.Instance.Create(game, position);
        }

        public void Update(GameTime gameTime)
        {
            starSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch batch)
        {
            starSprite.Draw(batch);
        }
    }
}