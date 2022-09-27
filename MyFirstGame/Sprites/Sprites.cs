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
     class NormalMarioStandingSprite :MarioSprite
    {
        public NormalMarioStandingSprite(Game1 game, Vector2 position, SpriteEffects orientation)
            : base (game.Content.Load<Texture2D>("small-standing-mario"), position, game.Content.Load<Texture2D>("small-walking-mario"),
                  game.Content.Load<Texture2D>("small-jumping-mario"), game.Content.Load<Texture2D>("small-crouching-mario"),orientation)
        {

        }
    }


    class FireMarioStandingSprite : MarioSprite
    {
        public FireMarioStandingSprite(Game1 game, Vector2 position, SpriteEffects orientation)
            : base(game.Content.Load<Texture2D>("fire-standing-mario"), position, game.Content.Load<Texture2D>("fire-walking-mario"),
                  game.Content.Load<Texture2D>("fire-jumping-mario"), game.Content.Load<Texture2D>("fire-crouching-mario"), orientation)
        {

        }
    }


    class SuperMarioStandingSprite : MarioSprite
    {
        public SuperMarioStandingSprite(Game1 game, Vector2 position, SpriteEffects orientation)
            : base(game.Content.Load<Texture2D>("super-standing-mario"), position, game.Content.Load<Texture2D>("super-walking-mario"),
                  game.Content.Load<Texture2D>("super-jumping-mario"), game.Content.Load<Texture2D>("super-crouching-mario"), orientation)
        {

        }
    }

    class DeadMarioSprite : MarioSprite
    {
        public DeadMarioSprite(Game1 game, Vector2 position, SpriteEffects orientation)
            : base(game.Content.Load<Texture2D>("dead-mario"), position, game.Content.Load<Texture2D>("dead-mario"),
                  game.Content.Load<Texture2D>("dead-mario"), game.Content.Load<Texture2D>("dead-mario"), orientation)
        {

        }
    }
}
