using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Sprites
{
    class GoombaSprite : Sprite
    {
        public GoombaSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("goomba-standing"), position, Vector2.Zero, Point.Zero, new Point(1, 1), new Point(16, 21), false)
        {

        }
    }
    class KoopaTroopSprite : Sprite
    {
        public KoopaTroopSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("koopaTroopa-standing"), position, Vector2.Zero, Point.Zero, new Point(1, 1), new Point(17, 25), false)
        {

        }
    }

}
