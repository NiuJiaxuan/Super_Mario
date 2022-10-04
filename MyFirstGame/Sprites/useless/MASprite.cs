using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.interfaces;

namespace Sprint0.Sprites.useless
{
    public class MASprite
    {

        public Texture2D ma { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;

        public bool isVisible = false;

        public float speed = 2f;
        public Vector2 position;

        public MASprite(Texture2D texture, int rows, int columns, Vector2 vector2)
        {
            ma = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            position = vector2;
        }


        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }

            position.X -= speed;
            if (position.X < 0 || position.X > 800 - Width() / Columns)
            {
                speed = -speed;
            }

        }


        public void Draw(SpriteBatch spriteBatch)
        {
            int width = ma.Width / Columns;
            int height = ma.Height / Rows;
            int row = currentFrame / Columns;
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);

            if (isVisible)
            {
                spriteBatch.Draw(ma, destinationRectangle, sourceRectangle, Color.White);
            }
        }

        public int Width()
        {
            return ma.Width;
        }

        public int Height()
        {
            return ma.Height;
        }

        public void VisibleCommand()
        {
            isVisible = !isVisible;
        }

    }
}
