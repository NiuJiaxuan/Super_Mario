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
        private Sprite boundBox;
        public Game1 game;

        public Sprite Sprite
        {
            get { return _sprite; }
            set { _sprite = value; }
        }

        public Sprite BoundBox
        {
            get { return boundBox; }
            set { boundBox = value; }
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
        }

        public virtual void Update (GameTime gameTime/*, List<Entity> entities*/)
        {
            
            
            Sprite.Update(gameTime);
            
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        // rewrite later
        public bool isTouchingLeft(Entity entity)
        {
            
            return false;
        }
    }
}
