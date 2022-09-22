using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MyFirstGame.interfaces;
using Sprint0.Command;

namespace Sprint0.Controller
{
    internal class KeyboardController : IController
    {

        
        KeyboardState previousState;

        private ICommand ExitCommand { get; set; }       //q for quit this game
        private ICommand NmNaCommand { get; set; }       //non moving non animated
        private ICommand NmACommand { get; set; }        //non moving animated
        private ICommand MNaCommand { get; set; }        //moving non animated
        private ICommand MACommand { get; set; }         //movng animated


        public KeyboardController()
        {
            previousState = Keyboard.GetState();        //initialize previouse state inorder to avoid multi count for one key press
        }

        public void Update()
        {
            KeyboardState currentState = Keyboard.GetState();       //collect current key state
            Keys[] keysPressed = currentState.GetPressedKeys();     //collect keys that pressed

            foreach (Keys key in keysPressed)
            { 
                if (!previousState.IsKeyDown(key))                  //check if key is released
                {
                    switch (key)
                    {
                        case Keys.Q:        //q represent for quit this game
                            if (ExitCommand != null)
                                ExitCommand.Execute();
                            break;

                        case Keys.W:        //w for non moving non animated
                            if(NmNaCommand != null)
                                NmNaCommand.Execute();
                            break;

                        case Keys.E:        //e for non moving animated
                            if (NmACommand != null)
                                NmACommand.Execute();
                            break;

                        case Keys.R:        //r for moving non animated
                            if (MNaCommand != null)
                                MNaCommand.Execute();
                            break;

                        case Keys.T:        //t for moving animated
                            if (MACommand != null)
                                MACommand.Execute();
                            break;

                        default:
                            Debug.WriteLine(key.ToString() + " Pressed!");
                            break;


                    }
                }

            }

            previousState = currentState;

        }

    }
}
