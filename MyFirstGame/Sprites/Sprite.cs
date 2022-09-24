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
        Point currentFrame;
        Point animatedSpriteSize;
        int timeSinceLastFrame = 0;
        int delayTime;
        

        public Sprite(Texture2D texture, Vector2 position,Vector2 speed, bool isVisible, bool isAnimated, int delayTime, Point animatedSpriteSize)
        {
            this.texture = texture;
            this.position = position;
            this.speed = speed;
            this.isVisible = isVisible;
            this.isAnimated = isAnimated;
            this.delayTime = delayTime;
            this.animatedSpriteSize = animatedSpriteSize;
            currentFrame = new Point(0,0);

        }
        
        private void Animation(GameTime gameTime)
        {
            if (isAnimated)
            {
                timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
                if(timeSinceLastFrame >= delayTime)
                {
                    timeSinceLastFrame -= delayTime;
                    currentFrame.X++;
                    if(currentFrame.X >= animatedSpriteSize.X)
                    {
                        currentFrame.X = 0;
                        currentFrame.Y++;
                        if (currentFrame.Y >= animatedSpriteSize.Y)
                            currentFrame.Y = 0;
                    }
                }
            }
        }


        public void Update(GameTime gameTime)
        {

            Animation(gameTime);



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
