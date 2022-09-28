using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Items
{
    public class Coin
    {
        ISprite coinSprite;
        public Coin(Game1 game, Vector2 position)
        {
            coinSprite = CoinFactory.Instance.Create(game, position);
        }

        public void Update(GameTime gameTime)
        {
            coinSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch batch)
        {
            coinSprite.Draw(batch);
        }
    }
}
