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
    public abstract class Entity : ISprite
    {
        private Game1 _game;
        private Sprite _sprite;
        public Game1 game;
        public Vector2 position;

        public Sprite Sprite
        {
            get { return _sprite; }
            set { _sprite = value; }
        }

        public virtual SpriteEffects Orientation
        {
            get { return _sprite.Orientation; }
            set { _sprite.Orientation = value; }
        }

        public Vector2 Speed
        {
            get { return _sprite.Speed; }
            set { _sprite.Speed = value; }
        }

        public Vector2 Accelation
        {
            get { return _sprite.Accelation; }
            set { _sprite.Accelation = value; }
        }

        public Vector2 Position
        {
            get { return _sprite.Position; }
            set { _sprite.Position = value; }
        }

        public Entity (Game1 game, Vector2 position)
        {
            this.game = game; 
            Position = position;
        }

        public virtual void Update (GameTime gameTime)
        {
            _sprite.Update(gameTime);
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            _sprite.Draw(spriteBatch);
        }
    }
}
