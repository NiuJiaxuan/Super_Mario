using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Sprites
{
    public abstract class Entity 
    {
        private Sprite _sprite;
        public Game1 game;
        public bool showBoundBox;


        public Sprite Sprite
        {
            get { return _sprite; }
            set { _sprite = value; }
        }

        public Rectangle Rectangle
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, (int)Sprite.Width, (int)Sprite.Height); }
        }

        #region Colloision
        protected bool IsTouchingLeft(Entity entity)
        {
            return this.Rectangle.Right + this.Speed.X > entity.Rectangle.Left &&
              this.Rectangle.Left < entity.Rectangle.Left &&
              this.Rectangle.Bottom > entity.Rectangle.Top &&
              this.Rectangle.Top < entity.Rectangle.Bottom;
        }

        protected bool IsTouchingRight(Entity entity)
        {
            return this.Rectangle.Left + this.Speed.X < entity.Rectangle.Right &&
              this.Rectangle.Right > entity.Rectangle.Right &&
              this.Rectangle.Bottom > entity.Rectangle.Top &&
              this.Rectangle.Top < entity.Rectangle.Bottom;
        }

        protected bool IsTouchingTop(Entity entity)
        {
            return this.Rectangle.Bottom + this.Speed.Y > entity.Rectangle.Top &&
              this.Rectangle.Top < entity.Rectangle.Top &&
              this.Rectangle.Right > entity.Rectangle.Left &&
              this.Rectangle.Left < entity.Rectangle.Right;
        }

        protected bool IsTouchingBottom(Entity entity)
        {
            return this.Rectangle.Top + this.Speed.Y < entity.Rectangle.Bottom &&
              this.Rectangle.Bottom > entity.Rectangle.Bottom &&
              this.Rectangle.Right > entity.Rectangle.Left &&
              this.Rectangle.Left < entity.Rectangle.Right;
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
        }

        public virtual void Update (GameTime gameTime, List<Entity> entities)
        {
            
            
            Sprite.Update(gameTime);
            
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }
    }
}
