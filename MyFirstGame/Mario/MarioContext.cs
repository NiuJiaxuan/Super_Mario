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
using System.Diagnostics;

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
            lifecount = 1;
            currentState = new NormalMario(this);
        }
        public void ChangeToSuper()
        {
            lifecount = 2;
            currentState = new SuperMario(this);
        }
        public void ChangeToFire()
        {
            lifecount = 3;
            currentState = new FireMario(this);
        }
        public void TakeDamage()
        {
            lifecount--;
            switch (lifecount)
            {
                case 0: 
                    currentState = new DeadMario(this); 
                    break;
                case 1: 
                    currentState = new NormalMario(this); 
                    break;
                case 2: 
                    currentState = new SuperMario(this); 
                    break;
            }
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
