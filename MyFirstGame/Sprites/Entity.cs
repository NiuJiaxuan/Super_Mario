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

namespace Sprint0.Sprites
{
    public abstract class Entity 
    {
        private Sprite _sprite;
        public Game1 game;
        public GraphicsDevice graphics;
        public bool showBoundBox;
        public Texture2D texture;
        public Collision collisionDetection;
        public MarioEntity Mario;

        public Sprite Sprite
        {
            get { return _sprite; }
            set { _sprite = value; }
        }

        public List<Entity> Entities
        {
            get; set;
        }

        public Rectangle GetRectangle
        {
            get { return new Rectangle((int)Position.X, (int)(Position.Y- Sprite.FrameSize.Y), (int)Sprite.FrameSize.X, (int)Sprite.FrameSize.Y); }
        }

        public Collision Collision
        {
            get { return collisionDetection; }
            set { this.collisionDetection = value; }
        }

        #region Colloision
        protected bool IsTouchingLeft(Entity entity)
        {
            Rectangle intersectRectangule = Rectangle.Intersect(GetRectangle, entity.GetRectangle);
            if (!intersectRectangule.IsEmpty)
            {
            }

            return false;
            //return this.GetRectangle.Right /*+ this.Speed.X */> entity.GetRectangle.Left &&
            //  this.GetRectangle.Left < entity.GetRectangle.Left &&
            //  this.GetRectangle.Bottom > entity.GetRectangle.Top &&
            //  this.GetRectangle.Top < entity.GetRectangle.Bottom;
        }

        protected bool IsTouchingRight(Entity entity)
        {
            return this.GetRectangle.Left + this.Speed.X < entity.GetRectangle.Right &&
              this.GetRectangle.Right > entity.GetRectangle.Right &&
              this.GetRectangle.Bottom > entity.GetRectangle.Top &&
              this.GetRectangle.Top < entity.GetRectangle.Bottom;
        }

        protected bool IsTouchingTop(Entity entity)
        {
            return this.GetRectangle.Bottom /*+ this.Speed.Y */> entity.GetRectangle.Top &&
              this.GetRectangle.Top < entity.GetRectangle.Top &&
              this.GetRectangle.Right > entity.GetRectangle.Left &&
              this.GetRectangle.Left < entity.GetRectangle.Right;
        }

        protected bool IsTouchingBottom(Entity entity)
        {
            return this.GetRectangle.Top/* + this.Speed.Y*/ < entity.GetRectangle.Bottom &&
              this.GetRectangle.Bottom > entity.GetRectangle.Bottom &&
              this.GetRectangle.Right > entity.GetRectangle.Left &&
              this.GetRectangle.Left < entity.GetRectangle.Right;
        }

        #endregion

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
            Collision = new Collision(this);

        }

        public virtual void Update (GameTime gameTime, List<Entity> entities, MarioEntity mario)
        {

            this.Entities = entities;
            Mario = mario;
            Sprite.Update(gameTime);
            //Debug.WriteLine(Sprite.Height, Sprite.FrameSize.Y.ToString());
        }
        public virtual void Update(GameTime gameTime, List<Entity> entities)
        {

            this.Entities = entities;
            Sprite.Update(gameTime);
            //Debug.WriteLine(Sprite.Height, Sprite.FrameSize.Y.ToString());
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if(showBoundBox)
            RectangleSprite.DrawRectangle(spriteBatch, GetRectangle, Color.Green, 2);
            Sprite.Draw(spriteBatch);
        }

//----------------------------------------Show Bound Box Command-----------------------------------

        public virtual void ShowBoundBox()
        {
            showBoundBox = !showBoundBox;
        }
    }
}
