using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.State;
using Sprint0.interfaces;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;
using Microsoft.Xna.Framework;

namespace Sprint0.State
{
     class MarioContext11
    {

        private IState currentState;
        private Dictionary<String, IState> movingStates;
        private Dictionary<String, IState> powerState;

        private ISprite mario;

        public MarioContext11(Game1 game, Vector2 pos)
        {
        }

        public void stateChange()
        {

        }

        public void Update()
        {

        }

        public void Draw()
        {

        }

    }
}
 