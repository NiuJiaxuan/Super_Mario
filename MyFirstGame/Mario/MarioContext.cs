using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controller;
using Sprint0.interfaces;
using Sprint0.Sprites;
using Sprint0.State;
using Sprint0.Command;
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

        private IState currentState;


        public int lifecount;

        public Game1 game;
        public Vector2 position;


        public MarioContext(Game1 game, Vector2 position)
        {
            this.game = game;
            this.position = position;

            currentState = new NormalMario(this);
            lifecount = 1;

        }


        public void setState(IState state)
        {
            currentState = state;
        }


        

        public void ChangeToNormal()
        {
            currentState = new NormalMario(this);
        }
        public void ChangeToFire()
        {
            if(lifecount<3 && lifecount>0)
                lifecount++;
            currentState = new FireMario(this);
        }
        public void ChangeToSuper()
        {
            if(lifecount<3 && lifecount>0)
                lifecount++;
            currentState = new SuperMario(this);
        }
        public void TakeDamage()
        {
            lifecount--;
            if (lifecount <= 0)
                currentState = new DeadMario(this);
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
