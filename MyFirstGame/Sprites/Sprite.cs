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

        Vector2 position;
        Texture2D texture;
        Vector2 speed;


        bool isVisible;


        bool isAnimated;
        int currentFrame;
        int totalFrames;


        public Sprite(Texture2D texture, Vector2 position,Vector2 speed, bool isVisible, bool isAnimated )
        {
            this.texture = texture;
            this.position = position;
            this.speed = speed;
            this.isVisible = isVisible;
            this.isAnimated = isAnimated;

        }
        


        public void Update()
        {

        }


        public void Draw(SpriteBatch batch)
        {
            batch.Draw(texture, position, Color.White);
        }


        public int Height()
        {
            return texture.Height;
        }

        public int Width()
        {
            return texture.Width;
        }
    }
}
