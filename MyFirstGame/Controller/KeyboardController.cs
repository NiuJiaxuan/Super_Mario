using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.interfaces;
using Sprint0.Command;

namespace Sprint0.Controller
{
    internal class KeyboardController : Controllers
    {

        
        KeyboardState previousState;

        public KeyboardController()
        {
            previousState = Keyboard.GetState();        //initialize previouse state inorder to avoid multi count for one key press
        }

        public override void Update()
        {
            KeyboardState currentState = Keyboard.GetState();       //collect current key state
            Keys[] keysPressed = currentState.GetPressedKeys();     //collect keys that pressed

            foreach (Keys key in keysPressed)
            { 
                if (!previousState.IsKeyDown(key))                  //check if key is released
                {

                    if (commands.ContainsKey((int)key)) commands[(int)key].Execute();

                }
            }

            previousState = currentState;

        }

    }
}
