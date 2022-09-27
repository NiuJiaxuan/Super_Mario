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
        public Texture2D texture;
        Vector2 speed;

        bool isVisible;

        bool isAnimated;
        Point currentFrame;
        Point animatedSpriteSize;
        Point frameSize;
        int timeSinceLastFrame = 0;
        int delayTime;

        public float velocity = 4f;
        public float horizonVelocity = 2f;
        public float verticalVelocity = 4f;
        public bool isBump = false;
        public bool isAppear = false;
        public bool isSuperMario = false;
        public double bumpHeight;
        public double originHight;
        public double h;



        public Sprite(Texture2D texture, Vector2 position,Vector2 speed, bool isVisible, bool isAnimated, int delayTime, Point animatedSpriteSize, Point frameSize)
        {
            this.texture = texture;
            this.position = position;
            this.speed = speed;
            this.isVisible = isVisible;
            this.isAnimated = isAnimated;
            this.delayTime = delayTime;
            this.frameSize = frameSize;
            this.animatedSpriteSize = animatedSpriteSize;
            bumpHeight = position.Y - 25;
            originHight = position.Y;
            h = position.Y - 60;
            currentFrame = new Point(0,0);
        }
        
        public void Bump(GameTime gameTime)
        {
            if (isBump && !isSuperMario)
            {
                position.Y -= velocity;
                if (position.Y < bumpHeight)
                {
                    velocity = -velocity;
                }
                if (position.Y > originHight)
                {
                    velocity = 0;
                }
            }
        }

        public void Appear(GameTime gameTime)
        {
            if (isAppear)
            {
                
                if (position.Y > h)
                {
                    position.Y -= velocity;
                }
                if(position.Y < h+38)
                {
                    velocity = 0;
                }
            }
        }

        public void Fall(GameTime gameTime)
        {
            if (isSuperMario)
            {
                position.Y += verticalVelocity;
                verticalVelocity += 1f;
                position.X += horizonVelocity;
                if (horizonVelocity > 0)
                {
                    horizonVelocity -= 1f;
                }
            }
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

            Bump(gameTime);
            
            Appear(gameTime);
            Fall(gameTime);

        }


        public void Draw(SpriteBatch batch)
        {
            if (isVisible)
            {
                batch.Draw(texture, position,
                    new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y,
                    frameSize.X, frameSize.Y),
                    Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            }
        }



        public int Height()
        {
            return texture.Height;
        }

        public int Width()
        {
            return texture.Width;
        }

        public void IsBump()
        {
            isBump = true;
        }

        public void IsAppear()
        {
            isAppear = true;
        }

        public void ChangeToVisible()
        {
            isVisible = true;
        }

        public void HideSprite()
        {
            isVisible = false;
        }

        public void IsSuperMario()
        {
            isSuperMario = true;
        }
        public void NegativeHorizonVelocity()
        {
            horizonVelocity = -horizonVelocity;
        }

    }
}
