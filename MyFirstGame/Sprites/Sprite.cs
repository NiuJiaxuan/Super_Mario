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
    public class Sprite : ISprite
    {
        // Texture
        public Texture2D texture { get; set; }
        public Tile Tile { get; set; }
        // Movement
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public Vector2 Accelation { get; set; }

        public int DelayTime { get { return Tile.DelayTime; } set { Tile.DelayTime = value; } }

        public Point FrameSize { get { return Tile.frameSize; } }

        public SpriteEffects Orientation { get; set; }  


        public Sprite(Texture2D texture, Vector2 position,Vector2 speed,
            Point frameOrigin,  Point sheetSize, Point frameSize, bool isAnimated)
        {
            Tile = new Tile(texture, frameOrigin, sheetSize, frameSize, isAnimated);
            this.texture = texture;
            this.Position = position;
            this.Speed = speed;
            Orientation = SpriteEffects.None;
        }


        public float Width
        {
             get { return texture.Width; }
        }
        public float Height
        {
            get { return texture.Height; }
        }



        public void Update(GameTime gameTime)
        {
            Tile.Update(gameTime);
        }


        public void Draw(SpriteBatch batch)
        {
            Tile.Draw(batch,Position, Orientation);
        }



    }
}
