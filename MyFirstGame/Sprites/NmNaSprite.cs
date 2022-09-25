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
    public class NmNaSprite 
    {
        public Texture2D NmNa { get; set; }
        public Vector2 Position;
        public Boolean isVisible = false;


        public NmNaSprite(Texture2D nmNa, Vector2 position)
        {
            NmNa = nmNa;
            Position = position;
        }

        public void Update()
        {

        }

        public int Width()
        {
            return NmNa.Width;
        }

        public int Height()
        {
            return NmNa.Height;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible)
            {
                spriteBatch.Draw(NmNa, Position, Color.White);

            }
        }

        public void VisibleCommand()
        {
            isVisible = !isVisible;
        }
    }
}
