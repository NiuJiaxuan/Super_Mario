using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0.Sprites
{
    public class MNaSprite : ISprite
    {

        public Texture2D MNa { get; set; }
        public float speed = 2f;

        public Boolean isVisible = false;

        public Vector2 Postion;

        //basic initialization method for moving non animated sprite
        public MNaSprite (Texture2D texture, Vector2 postion)
        {
            MNa = texture;
            Postion = postion;
        }


        // draw allow sprite to show up 
         public void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible)
            {
                spriteBatch.Draw(MNa, Postion, Color.White);
            }
        }

         public int Height()
        {
            return MNa.Height;
        }
         public int Width()
        {
            return MNa.Width;
        }


         public void Update()
        {
            Postion.Y -= speed;
            if(Postion.Y <= 0 || Postion.Y >= (480 - this.Height()))
            {
                speed = -speed;
            } 

        }

        public void VisibleCommand()
        {
            isVisible = !isVisible;
        }

    }
}
