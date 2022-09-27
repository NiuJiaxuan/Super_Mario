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
        public NormalMarioStandingSprite(Game1 game, Vector2 position, SpriteEffects orientation)
            : base (game.Content.Load<Texture2D>("small-standing-mario"), position,new Vector2(0,0), true,false,0,Point.Zero, new Point(18,24),orientation )
        {

        }
    }

    class NormalMarioRunningSprite : Sprite
    {
        public NormalMarioRunningSprite(Game1 game, Vector2 position,Vector2 speed, SpriteEffects orientation)
            : base(game.Content.Load<Texture2D>("small-standing-mario"), position,speed, true, false, 0, Point.Zero, new Point(18, 24), orientation)
        {

        }
    }


    class FireMarioStandingSprite : Sprite
    {
        public FireMarioStandingSprite(Game1 game1, Vector2 vector2, SpriteEffects orientation)
            : base(game1.Content.Load<Texture2D>("fire-standing-mario"), vector2, new Vector2(0, 0), true, false, 0, Point.Zero, new Point(22,48), orientation)
        {

        }
    }


    class SuperMarioStandingSprite : Sprite
    {
        public SuperMarioStandingSprite(Game1 game1, Vector2 vector2, SpriteEffects orientation)
            : base(game1.Content.Load<Texture2D>("super-standing-mario"), vector2, new Vector2(0, 0), true, false, 0, Point.Zero, new Point(22, 48),  orientation)
        {

        }
    }

    class DeadMarioSprite : Sprite
    {
        public DeadMarioSprite(Game1 game1, Vector2 vector2, SpriteEffects orientation)
            : base(game1.Content.Load<Texture2D>("dead-mario"), vector2, new Vector2(0, 0), true, false, 0, Point.Zero, new Point(18,18), orientation)
        {

        }
    }
}
