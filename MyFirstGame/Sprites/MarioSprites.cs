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
 //----------------------------------------------------------------Normal Mario----------------------------------------------------------------------
    class NormalMarioIdleSprite : Sprite
    {
        public NormalMarioIdleSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("small-standing-mario"),position, Vector2.Zero, Point.Zero, new Point(1,1), new Point(18,24), false)
        {

        }
    }

    class NormalMarioJumpSprite : Sprite
    {
        public NormalMarioJumpSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("small-jumping-mario"), position, Vector2.Zero, Point.Zero, new Point(1, 1), new Point(18, 18), false)
        {

        }
    }

    class NormalMarioWalkSprite : Sprite
    {
        public NormalMarioWalkSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("small-walking-mario"), position, Vector2.Zero, Point.Zero, new Point(3, 1), new Point(24, 24), true)
        {

        }
    }

    class NormalMarioCrouchSprite : Sprite
    {
        public NormalMarioCrouchSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("small-standing-mario"), position, Vector2.Zero, Point.Zero, new Point(1, 1), new Point(18, 24), false)
        {

        }
    }

//-------------------------------------------------------Fire Mario-------------------------------------------------------------------------

    class FireMarioIdleSprite : Sprite
    {
        public FireMarioIdleSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("fire-standing-mario"), position, Vector2.Zero, Point.Zero, new Point(1, 1), new Point(22,48), false)
        {

        }
    }
    class FireMarioJumpSprite : Sprite
    {
        public FireMarioJumpSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("fire-jumping-mario"), position, Vector2.Zero, Point.Zero, new Point(1, 1), new Point(22, 43), false)
        {

        }
    }
    class FireMarioWalkSprite : Sprite
    {
        public FireMarioWalkSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("fire-walking-mario"), position, Vector2.Zero, Point.Zero, new Point(3, 1), new Point(22, 46), true)
        {

        }
    }
    class FireMarioCrouchSprite : Sprite
    {
        public FireMarioCrouchSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("fire-crouching-mario"), position, Vector2.Zero, Point.Zero, new Point(1, 1), new Point(17, 24), false)
        {

        }
    }

//--------------------------------------------------------------Super Mario--------------------------------------------------------------------------
    class SuperMarioIdleSprite : Sprite
    {
        public SuperMarioIdleSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("super-standing-mario"), position, Vector2.Zero, Point.Zero, new Point(1, 1), new Point(22, 48), false)
        {

        }
    }
    class SuperMarioJumpSprite : Sprite
    {
        public SuperMarioJumpSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("large-jumping-mario"), position, Vector2.Zero, Point.Zero, new Point(1, 1), new Point(22, 43), false)
        {

        }
    }
    class SuperMarioWalkSprite : Sprite
    {
        public SuperMarioWalkSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("large-walking-mario"), position, Vector2.Zero, Point.Zero, new Point(3, 1), new Point(22, 46), true)
        {
            
        }
    }
    class SuperMarioCrouchSprite : Sprite
    {
        public SuperMarioCrouchSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("large-crouching-mario"), position, Vector2.Zero, Point.Zero, new Point(1, 1), new Point(17, 24), false)
        {

        }
    }

//--------------------------------------------------------Dead Mario------------------------------------------------------------------------------
    class DeadMarioSprite : Sprite
    {
        public DeadMarioSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("dead-mario"), position, Vector2.Zero, Point.Zero, new Point(1, 1), new Point(18,18), false)
        {

        }
    }
}
