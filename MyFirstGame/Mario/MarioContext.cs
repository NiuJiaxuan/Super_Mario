using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controller;
using Sprint0.interfaces;
using Sprint0.Sprites;
using Sprint0.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Sprint0.Mario
{
    public class MarioContext
    {



        private IController keyboard;


        private IState currentState;

        public Game1 game;
        public Vector2 position;


        public MarioContext(Game1 game, Vector2 position)
        {
            this.game = game;
            this.position = position;

            currentState = new NormalMario(this);
        }


        public void setState(IState state)
        {
            currentState = state;
        }


         

        private void commandSetup()
        {
            keyboard = new KeyboardController();

        }



        public void PowerChanges(GameTime gameTime)
        {
           
            currentState.Update(gameTime);


        }

        public void Update(GameTime gameTime)
        {
            currentState.Update(gameTime);
        }

        public void Draw(SpriteBatch batch)
        {
            currentState.Draw(batch);
        }
    }
}
