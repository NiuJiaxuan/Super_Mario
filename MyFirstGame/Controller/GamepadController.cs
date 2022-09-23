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

        private PlayerIndex playerIndex;
        GamePadState previousState, emptyState;

        
        public GamepadController(PlayerIndex index)
        {
            playerIndex = index;
            previousState = GamePad.GetState(playerIndex);
            emptyState = new GamePadState();
        }

        public override void Update()
        {
            GamePadState currentState = GamePad.GetState(playerIndex);

            if (currentState.IsConnected)
            {
                if(currentState != emptyState)
                {
                    var buttonList = (Buttons[])Enum.GetValues(typeof(Buttons));
                    foreach (var button in buttonList)
                    {
                        if (currentState.IsButtonDown(button) && !previousState.IsButtonDown(button))
                            if (commands.ContainsKey((int)button))
                                commands[(int)button].Execute();
                    }
                }
            }

            previousState = currentState;
        }


    }
}
