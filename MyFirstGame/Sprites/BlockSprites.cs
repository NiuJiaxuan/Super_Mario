using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.interfaces;

namespace Sprint0.Sprites
{
    class QuestionBlockSprite : Sprite
    {
        public QuestionBlockSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("questionBlock"), position, Vector2.Zero, Point.Zero, new Point(3, 1), new Point(100, 31), true)
        {

        }
    }

    class BrickBlockSprite : Sprite
    {
        public BrickBlockSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("brickblock"), position, Vector2.Zero, Point.Zero, new Point(1, 1), new Point(30, 30), false)
        {

        }
    }

    class FloorBlockSprite : Sprite
    {
        public FloorBlockSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("floorBlock"), position, Vector2.Zero, Point.Zero, new Point(1, 1), new Point(30, 30), false)
        {

        }
    }

    class StairBlockSprite : Sprite
    {
        public StairBlockSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("stairBlock"), position, Vector2.Zero, Point.Zero, new Point(1, 1), new Point(30, 30), false)
        {

        }
    }

    class SmallBrickBlockSprite : Sprite
    {
        public SmallBrickBlockSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("smallBrickBlock"), position, Vector2.Zero, Point.Zero, new Point(1, 1), new Point(15, 15), false)
        {

        }
    }
}