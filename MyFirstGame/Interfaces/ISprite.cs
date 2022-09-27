using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Sprint0.interfaces
{
    public interface ISprite
    {
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
        int Width();
        int Height();
        void IsBump();
        void ChangeToVisible();
        void HideSprite();
        void IsAppear();
        void IsSuperMario();
        void NegativeHorizonVelocity();
    }
}