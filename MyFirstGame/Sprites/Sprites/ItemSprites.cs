using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Sprites.Sprites
{
    class CoinSprite : Sprite
    {
        public CoinSprite(Game1 game, Vector2 position)
           : base(game.Content.Load<Texture2D>("Coin"), position, Vector2.Zero, Point.Zero, new Point(6, 1), new Point(214 / 6, 30), true)
        {
            DelayTime = 100;
        }
    }

    class FireFlowerSprite : Sprite
    {
        public FireFlowerSprite(Game1 game, Vector2 position)
           : base(game.Content.Load<Texture2D>("FireFlower"), position, Vector2.Zero, Point.Zero, new Point(2, 1), new Point(58 / 2, 30), true)
        {
            DelayTime = 300;
        }
    }

    class StarSprite : Sprite
    {
        public StarSprite(Game1 game, Vector2 position)
           : base(game.Content.Load<Texture2D>("Star"), position, Vector2.Zero, Point.Zero, new Point(3, 2), new Point(91 / 3, 30), true)
        {
            DelayTime = 150;
        }
    }

    class SuperMushroomSprite : Sprite
    {
        public SuperMushroomSprite(Game1 game, Vector2 position)
           : base(game.Content.Load<Texture2D>("SuperMushroom"), position, Vector2.Zero, Point.Zero, new Point(1, 1), new Point(30, 30), false)
        {

        }
    }

    class OneUpMushroomSprite : Sprite
    {
        public OneUpMushroomSprite(Game1 game, Vector2 position)
           : base(game.Content.Load<Texture2D>("1upMushroom"), position, Vector2.Zero, Point.Zero, new Point(1, 1), new Point(30, 30), false)
        {

        }
    }
    class PipeSprite : Sprite
    {
        public PipeSprite(Game1 game, Vector2 position)
           : base(game.Content.Load<Texture2D>("Pipe"), position, Vector2.Zero, Point.Zero, new Point(1, 1), new Point(60, 60), false)
        {

        }
    }
    class FireballSprite : Sprite
    {
        public FireballSprite(Game1 game, Vector2 position)
           : base(game.Content.Load<Texture2D>("fireball"), position, Vector2.Zero, Point.Zero, new Point(1, 1), new Point(12, 10), false)
        {

        }
    }
    class CastleSprite : Sprite
    {
        public CastleSprite(Game1 game, Vector2 position)
           : base(game.Content.Load<Texture2D>("castle"), position, Vector2.Zero, Point.Zero, new Point(1, 1), new Point(200, 236), false)
        {

        }

    }
    class FlagPoleSprite : Sprite
    {
        public FlagPoleSprite(Game1 game, Vector2 position)
           : base(game.Content.Load<Texture2D>("Flag"), position, Vector2.Zero, Point.Zero, new Point(1, 1), new Point(33, 170), false)
        {

        }

    }
}
