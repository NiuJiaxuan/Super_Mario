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

        int delayTime;
        int timeSinceLastFrame;
        Point currentFrame;
        Point animatedSpriteSize;
        Point frameSize;




        public int Rows;
        public int Columns;

        public KeyboardState movementDir;
        public string direction;

        public int speed;
        private Texture2D marioRight;
        private int marioRightRow;
        private int marioRightColumn;
        private Texture2D marioStandingLeft;
        private Texture2D marioStandingRight;

        private Texture2D marioJumpingRight;
        private int marioJumpingRightRows;
        private int marioJumpingRightColumns;
        private Texture2D marioJumpingLeft;
        private int marioJumpingLeftRows;
        private int marioJumpingLeftColumns;


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




            mario = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            position = vector2;
            Next = false;
            speed = 15;
            TimeSinceLastFrame = 0;
            MillisecondsPerFrame = 250;
            direction = "";

            marioRight = marioRightMain;
            marioRightRow = rows2;
            marioRightColumn = columns2;
            marioStandingLeft = marioStandingLeftMain;
            marioStandingRight = marioStandingRightMain;

            marioJumpingLeft = marioJumpingLeftMain;
            marioJumpingLeftRows = rows3;
            marioJumpingLeftColumns = columns3;

            marioJumpingRight = marioJumpingRightMain;
            marioJumpingRightRows = rows4;
            marioJumpingRightColumns = columns4;

            marioCrouching = marioCrouchingMain;
            isCrouch = false;
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
                HorizontalMovement();

            }
            else if (isJump)
            {
                velocity.Y = -10;
                velocity.X *= ori;
                HorizontalMovement();
            }
        }



        public void Draw(SpriteBatch spriteBatch)
        {
            int width = mario.Width / Columns;
            int height = mario.Height / Rows;
            int row = currentFrame / Columns;
            int column = currentFrame % Columns;

            Rectangle sourceRectangle;
            Rectangle destinationRectangle;


            Debug.WriteLine(direction);
            if (pressed)
            {



                if (direction.Equals("left"))
                {
                    MoveLeft();
                    sourceRectangle = new Rectangle(width * column, height * row, width, height);
                    destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
                    spriteBatch.Draw(mario, destinationRectangle, sourceRectangle, Color.White);

                }
                else if (direction.Equals("right"))
                {
                    MoveRight();
                    width = mario.Width / marioRightColumn;
                    height = mario.Height / marioRightRow;
                    row = currentFrame / marioRightColumn;
                    column = currentFrame % marioRightColumn;

                    sourceRectangle = new Rectangle(width * column, height * row, width, height);
                    destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
                    spriteBatch.Draw(marioRight, destinationRectangle, sourceRectangle, Color.White);
                }
            }
            else if (isJump)
            {
                if (direction.Equals("left"))
                {

                    width = mario.Width / marioJumpingLeftColumns;
                    height = mario.Height / marioJumpingLeftRows;
                    row = currentFrame / marioJumpingLeftColumns;
                    column = currentFrame % marioJumpingLeftColumns;

                    sourceRectangle = new Rectangle(width * column, height * row, width, height);
                    destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
                    Debug.WriteLine("Left Jump");
                    spriteBatch.Draw(marioJumpingLeft, destinationRectangle, sourceRectangle, Color.White);
                }
                else if (direction.Equals("right"))
                {
                    width = mario.Width / marioJumpingRightColumns;
                    height = mario.Height / marioJumpingRightRows;
                    row = currentFrame / marioJumpingRightColumns;
                    column = currentFrame % marioJumpingRightColumns;

                    sourceRectangle = new Rectangle(width * column, height * row, width, height);
                    destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
                    spriteBatch.Draw(marioJumpingRight, destinationRectangle, sourceRectangle, Color.White);
                }
                else
                {
                    sourceRectangle = new Rectangle(width * column, height * row, width, height);
                    destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
                    Debug.WriteLine("else Jump");
                    spriteBatch.Draw(mario, destinationRectangle, sourceRectangle, Color.White);
                }

            }

            else if (isCrouch)
            {
                spriteBatch.Draw(marioCrouching, position, Color.White);
            }
            else if (direction.Equals("left"))
            {
                spriteBatch.Draw(marioStandingLeft, position, Color.White);
            }
            else if (direction.Equals("right"))
            {
                spriteBatch.Draw(marioStandingRight, position, Color.White);
            }
            else
            {
                spriteBatch.Draw(marioStanding, position, 
                    new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y,
                    frameSize.X, frameSize.Y),
                    Color.White, 0, Vector2.Zero, 1, orientation, 0);
            }
        }

 
        private void NextFrame(GameTime gameTime, ref bool next)
        {
            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (TimeSinceLastFrame > MillisecondsPerFrame)
            {
                TimeSinceLastFrame -= MillisecondsPerFrame;
                next = true;
            }
            else
            {
                next = false;
            }

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
