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
    public class Tile 
    {
        // Texture
        public Texture2D Texture { get; private set; }


        // Animation
        public bool isAnimated { get; set; }

        public Point currentFrame = new Point(0, 0);
        public Point CurrentFrame
        {
            get { return currentFrame; }
            set { currentFrame = value; }
        }

        public Point frameOrigin { get; set; }
        public Point sheetSize { get; set; }
        public Point frameSize { get; set; }


        public int timeSinceLastFrame = 0;

        public int delayTime = 100;
        public int DelayTime
        {
            get { return delayTime;}
            set { delayTime = value; }
        }

        public  Tile(Texture2D texture, Point frameOrigin, Point sheetSize, Point frameSize, bool isAnimated)
        {
            this.Texture = texture;
            this.frameOrigin = frameOrigin;
            this.sheetSize = sheetSize;
            this.frameSize = frameSize;
            this.isAnimated = isAnimated;
        }




        private void Animation(GameTime gameTime)
        {
            if (isAnimated)
            {
                timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
                if (timeSinceLastFrame >= delayTime)
                {
                    timeSinceLastFrame -= delayTime;
                    currentFrame.X++;
                    if (currentFrame.X >= sheetSize.X)
                    {
                        currentFrame.X = 0;
                        currentFrame.Y++;
                        if (currentFrame.Y >= sheetSize.Y)
                            currentFrame.Y = 0;
                    }
                }
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            Animation(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects orientation)
        {
            spriteBatch.Draw(Texture, new Vector2(position.X, position.Y-Texture.Height),
                new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y,
                frameSize.X, frameSize.Y),
                Color.White, 0, Vector2.Zero, 1, orientation, 0);
        }

    }
}
