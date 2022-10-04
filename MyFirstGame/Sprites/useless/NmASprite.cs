using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.interfaces;


namespace Sprint0.Sprites.useless
{
    public class NmASprite
    {
        public Texture2D nma { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;

        public bool isVisible = false;

        public Vector2 position;

        public NmASprite(Texture2D texture, int rows, int columns, Vector2 vector2)
        {
            nma = texture;
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
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            int width = nma.Width / Columns;
            int height = nma.Height / Rows;
            int row = currentFrame / Columns;
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
            if (isVisible)
            {
                spriteBatch.Draw(nma, destinationRectangle, sourceRectangle, Color.White);

            }
        }

        public int Width()
        {
            return nma.Width;
        }

        public int Height()
        {
            return nma.Height;
        }

        public void VisibleCommand()
        {
            isVisible = !isVisible;
        }

    }
}
