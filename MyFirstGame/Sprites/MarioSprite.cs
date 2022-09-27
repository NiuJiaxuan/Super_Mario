using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.interfaces;


namespace Sprint0.Sprites
{
    public class MarioSprite : ISprite
    {
        private bool Next;

        private int MillisecondsPerFrame;
        private int TimeSinceLastFrame;

        Texture2D currentTexture;

        Texture2D marioStanding;
        Texture2D marioWalking;
        Texture2D marioJumping;
        Texture2D marioCrouching;
        SpriteEffects orientation;


        public Boolean isVisible;
        public Vector2 position;
        public Vector2 velocity;

        public bool pressed = false;
        public bool isJump = false;
        private bool isCrouch;

        bool isAnimated;

        int delayTime = 50;
        int timeSinceLastFrame;
        Point currentFrame;
        Point animatedSpriteSize;
        Point frameSize;



        public MarioSprite(Texture2D marioStanding, Vector2 position, Texture2D marioWalking, Texture2D marioJumping, Texture2D marioCrouching, SpriteEffects orientation)
        {

            this.marioStanding = marioStanding;
            this.position = position;
            this.marioWalking = marioWalking;
            this.marioJumping = marioJumping;
            this.marioCrouching = marioCrouching;
            this.orientation = orientation;
            this.velocity = new Vector2(0, 0);
            this.currentFrame = new Point(0, 0);
            this.currentTexture = marioStanding;
            this.isAnimated = false;

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
                    if (currentFrame.X >= animatedSpriteSize.X)
                    {
                        currentFrame.X = 0;
                        currentFrame.Y++;
                        if (currentFrame.Y >= animatedSpriteSize.Y)
                            currentFrame.Y = 0;
                    }
                }
            }
        }

        private void HorizontalMovement()
        {
            position.X += velocity.X;
        }

        private void Jumping()
        {
            if (isJump)
            {
                float ground = position.Y;
                position.Y += velocity.Y;
                Debug.WriteLine(position.Y);
                if (position.Y <= 60)
                {
                    velocity.Y = -velocity.Y;
                    Debug.WriteLine(position.Y);
                    if (position.Y >= ground)
                    {
                        velocity.Y = 0;
                        isJump = false;
                    }
                }
            }
        }



        public void Update(GameTime gameTime)
        {
            changMarioSprite(gameTime);
            HorizontalMovement();
            Jumping();

        }


        private void changMarioSprite(GameTime gameTime)
        {                
            int ori = 1;
            if (orientation == SpriteEffects.FlipVertically) ori = -1;
            if (pressed)
            {
                velocity.X *= ori; 
                currentTexture = marioWalking;
                Animation(gameTime);

            }
            else if (isJump)
            {
                velocity.Y = -10;
                velocity.X *= ori;
                currentTexture = marioJumping;
            }
            else if (isCrouch)
            {
                currentTexture = marioCrouching;
            }
            else
            {
                currentTexture = marioStanding;
            }
        }



        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(marioStanding, position,                     
                new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y,
                frameSize.X, frameSize.Y),
                Color.White, 0, Vector2.Zero, 1, orientation, 0);
            
        }
        

        public void Animated()
        {
            isAnimated = !isAnimated;
        }

        public void MoveRight()
        {
            if (position.X < 400)
            {
                position.X += 1;
            }
        }

        public void MoveLeft()
        {
            if (position.X > 50)
            {
                position.X -= 1;
            }
        }

        public void Jump()
        {
            if (position.Y == 100)
            {
                isJump = true;
            }
        }

        public void Crouch()
        {
            isCrouch = !isCrouch;
        }

    }
}
