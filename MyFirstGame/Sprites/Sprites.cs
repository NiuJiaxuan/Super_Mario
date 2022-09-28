using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sprint0.Sprites
{
     class NormalMarioStandingSprite :Sprite
    {
        public NormalMarioStandingSprite(Game1 game, Vector2 position)
            : base (game.Content.Load<Texture2D>("small-standing-mario"), position,new Vector2(0,0), true,false,0,Point.Zero, new Point(18,24) )
        {

        }
    }


    class FireMarioStandingSprite : Sprite
    {
        public FireMarioStandingSprite(Game1 game1, Vector2 vector2)
            : base(game1.Content.Load<Texture2D>("fire-standing-mario"), vector2, new Vector2(0, 0), true, false, 0, Point.Zero, new Point(22,48))
        {

        }
    }


    class SuperMarioStandingSprite : Sprite
    {
        public SuperMarioStandingSprite(Game1 game1, Vector2 vector2)
            : base(game1.Content.Load<Texture2D>("super-standing-mario"), vector2, new Vector2(0, 0), true, false, 0, Point.Zero, new Point(22, 48))
        {

        }
    }

    class QuestionBlockSprite : Sprite
    {
        public QuestionBlockSprite(Game1 game1, Vector2 vector2)
            : base(game1.Content.Load<Texture2D>("questionBlock"), vector2, new Vector2(0, 0), true, true, 300, new Point(3,1), new Point(33, 30))
        { 
        }
 
    }
    class BrickBlockSprite : Sprite
    {
        public BrickBlockSprite(Game1 game1, Vector2 vector2)
            : base(game1.Content.Load<Texture2D>("brickblock"), vector2, new Vector2(0, 0), true, false, 0, Point.Zero, new Point(30, 30))
        {

        }

    }
    class UsedBlockSprite : Sprite
    {
        public UsedBlockSprite(Game1 game1, Vector2 vector2)
            : base(game1.Content.Load<Texture2D>("usedBlock"), vector2, new Vector2(0, 0), true, false, 0, new Point(1,1), new Point(30, 30))
        {
        }

    }
    class FloorBlockSprite : Sprite
    {
        public FloorBlockSprite(Game1 game1, Vector2 vector2)
            : base(game1.Content.Load<Texture2D>("floorBlock"), vector2, new Vector2(0, 0), true, false, 0, Point.Zero, new Point(30, 30))
        {
        }

    }
    class StairBlockSprite : Sprite
    {
        public StairBlockSprite(Game1 game1, Vector2 vector2)
            : base(game1.Content.Load<Texture2D>("stairBlock"), vector2, new Vector2(0, 0), true, false, 0, Point.Zero, new Point(31, 30))
        {
        }

    }
    class BrickBlockPieceSprite : Sprite
    {
        public BrickBlockPieceSprite(Game1 game1, Vector2 vector2)
            : base(game1.Content.Load<Texture2D>("smallBrickBlock"), vector2, new Vector2(0, 0), false, false, 0, Point.Zero, new Point(15, 15))
        {
        }

    }
    class CoinSprite : Sprite
    {
        public CoinSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("Coin"), position, new Vector2(0, 0), true, true, 50, new Point(6, 1), new(33, 28))
        {

        }
    }


    /*need to change */
    class StarSprite : Sprite
    {
        public StarSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("StarA"), position, new Vector2(0, 0), true, true, 100, new Point(4, 1), new(21, 16))
        {

        }
    }

    /*need to change */
    class FireFlowerSprite : Sprite
    {
        public FireFlowerSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("FireFlowerA"), position, new Vector2(0, 0), true, true, 100, new Point(2, 1), new(58 / 2, 30))
        {

        }
    }


    class SuperMushroomSprite : Sprite
    {
        public SuperMushroomSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("SuperMushroom"), position, new Vector2(0, 0), true, false, 100, new Point(1, 1), new(30, 30))
        {

        }
    }


    class OneUpMushroomSprite : Sprite
    {
        public OneUpMushroomSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("1UpMushroom"), position, new Vector2(0, 0), true, false, 100, new Point(1, 1), new(30, 30))
        {

        }
    }


}
