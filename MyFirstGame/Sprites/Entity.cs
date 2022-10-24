using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.interfaces;
using Sprint0.CollisionDetection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Mario;
using System.Threading;
using Microsoft.VisualBasic.FileIO;

namespace Sprint0.Sprites
{
    public abstract class Entity 
    {
        private Sprite _sprite;
        public Game1 game;
        public GraphicsDevice graphics;
        public bool showBoundBox;
        public Texture2D texture;
        public CollisionDetector collisionDetection;
        public MarioEntity Mario;
        public bool IsVisible = true;


        public Sprite Sprite
        {
            get { return _sprite; }
            set { _sprite = value; }
        }

        public List<Entity> Entities
        {
            get; set;
        }

        public struct BoundBox
        {
            public Point min;
            public Point max;
        }

        public Rectangle GetRectangle
        {
            get { return new Rectangle((int)Position.X, (int)(Position.Y- Sprite.FrameSize.Y), (int)Sprite.FrameSize.X, (int)Sprite.FrameSize.Y); }
        }

        public CollisionDetector Collision
        {
            get { return collisionDetection; }
            set { this.collisionDetection = value; }
        }


        public virtual SpriteEffects Orientation
        {
            get { return Sprite.Orientation; }
            set { Sprite.Orientation = value; }
        }

        public Vector2 Speed
        {             
            get { return Sprite.Speed; }
            set { Sprite.Speed = value; }
        }

        public Vector2 Accelation
        {
            get { return Sprite.Accelation; }
            set { Sprite.Accelation = value; }
        }

        public Vector2 Position
        {
            get { return Sprite.Position; }
            set { Sprite.Position = value; }
        }

        public Entity (Game1 game, Vector2 position)
        {
            this.game = game;
            showBoundBox = false;            
        }


        public virtual void CollisionResponse(Entity entity, Vector2 position, CollisionDetector.Touching touching) { }



        public virtual void Update (GameTime gameTime, List<Entity> entities)
        {


            this.Entities = entities;
            Sprite.Update(gameTime);           
            
            Speed += Accelation * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }



        public Color BoxColor { get; set; }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

            if(showBoundBox)
            RectangleSprite.DrawRectangle(spriteBatch, GetRectangle, Color.Green, 2);

            if(IsVisible)
            Sprite.Draw(spriteBatch);
        }

//----------------------------------------Show Bound Box Command-----------------------------------

        public virtual void ShowBoundBox()
        {
            showBoundBox = !showBoundBox;
        }
    }
}
