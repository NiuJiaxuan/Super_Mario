using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Sprites.Sprites
{
    class GoombaSprite : Sprite
    {
        //           : base(game.Content.Load<Texture2D>("FireFlower"), position, Vector2.Zero, Point.Zero, new Point(2, 1), new Point(58 / 2, 30), true)

        public GoombaSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("Goomba-Walking"), position, Vector2.Zero, Point.Zero, new Point(2, 1), new Point(50 / 2, 25), true)
        {

        }
    }

    class GoombaInjuredSprite : Sprite
    {
        public GoombaInjuredSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("goomba-injured"), position, Vector2.Zero, Point.Zero, new Point(1, 1), new Point(25, 10), false)
        {

        }
    }

    class KoopaTroopSprite : Sprite
    {
        public KoopaTroopSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("KoopaTroopa-Walking"), position, Vector2.Zero, Point.Zero, new Point(2, 1), new Point(50 / 2, 25), true)
        {

        }
    }

}
