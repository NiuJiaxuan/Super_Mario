using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.interfaces;
using Sprint0.State;
using Sprint0.Sprites;

namespace Sprint0.Mario
{
    public class MarioAvatar
    {
        private int lifeCount;
        private ISprite marioSprite;

        private IState currentState;

        public MarioContext marioContext;

        public MarioAvatar(Game1 game, Vector2 position)
        {
            marioContext = new MarioContext(game,position);
        }




        public void Update(GameTime gameTime)
        {
            marioContext.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            marioContext.Draw(spriteBatch);
        }
    }
}
