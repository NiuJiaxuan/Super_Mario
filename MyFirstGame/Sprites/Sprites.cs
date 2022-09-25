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

}
