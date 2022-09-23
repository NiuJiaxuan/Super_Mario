using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.interfaces;
using Sprint0;
using Sprint0.Command;

namespace Sprint0.Controller
{
    public class GamepadController : Controllers
    {

        private ICommand ExitCommand { get; set; }       //q for quit this game
        private ICommand NmNaCommand { get; set; }       //non moving non animated
        private ICommand NmACommand { get; set; }        //non moving animated
        private ICommand MNaCommand { get; set; }        //moving non animated
        private ICommand MACommand { get; set; }         //movng animated

        private PlayerIndex playerIndex;
        GamePadState previousState;

        
        public GamepadController(PlayerIndex index)
        {
            playerIndex = index;
            previousState = GamePad.GetState(playerIndex);
        }

        public override void Update()
        {
            GamePadState currentState = GamePad.GetState(playerIndex);

            if(currentState.IsButtonDown(Buttons.Start))
            {
                if(!previousState.IsButtonDown(Buttons.Start))
                {
                    System.Diagnostics.Debug.WriteLine("start pressed");
                    if (ExitCommand != null)
                        ExitCommand.Execute();
                }

            }else if (currentState.IsButtonDown(Buttons.A))
            {
                if(!previousState.IsButtonDown(Buttons.A))
                {
                    System.Diagnostics.Debug.WriteLine("a pressed");
                    if (NmNaCommand != null)
                        NmNaCommand.Execute();
                }

            } else if (currentState.IsButtonDown(Buttons.B))
            {
                if (!previousState.IsButtonDown(Buttons.B))
                {
                    if(NmACommand != null)
                        NmACommand.Execute();
                }
            } else if (currentState.IsButtonDown(Buttons.X))
            {
                if (!previousState.IsButtonDown(Buttons.X))
                {
                    if (MNaCommand != null)
                        MNaCommand.Execute();
                }
            } else if (currentState.IsButtonDown(Buttons.Y))
            {
                if (!previousState.IsButtonDown(Buttons.Y))
                {
                    if (MACommand != null)
                        MACommand.Execute();
                }
            }


            previousState = currentState;
        }


    }
}
