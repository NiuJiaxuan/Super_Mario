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


}
