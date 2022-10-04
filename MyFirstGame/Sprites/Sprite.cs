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

        // Movement
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public Vector2 Accelation { get; set; }

        // Visible
        public bool isVisible { get; set; }

        public Point FrameSize { get { return tile.frameSize; } }

        public SpriteEffects Orientation { get; set; }  

        Tile tile;

        public Sprite(Texture2D texture, Vector2 position,Vector2 speed,
            Point frameOrigin,  Point sheetSize, Point frameSize, bool isAnimated)
        {
            tile = new Tile(texture, frameOrigin, sheetSize, frameSize, isAnimated);
            this.texture = texture;
            this.Position = position;
            this.Speed = speed;
            Orientation = SpriteEffects.None;
        }


        public float Width { get; set; }
        public float Height { get; set; }



        public void Update(GameTime gameTime)
        {
            tile.Update(gameTime);
        }


        public void Draw(SpriteBatch batch)
        {
            tile.Draw(batch,Position, Orientation);
        }



    }
}
