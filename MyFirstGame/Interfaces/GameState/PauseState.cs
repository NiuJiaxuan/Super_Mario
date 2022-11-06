﻿using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Block.State.GameState
{
    public class PauseState : IGameState
    {
        public Interfaces.GameStates Type
        {
            get
            {
                return Interfaces.GameStates.Pause;
            }
        }
        public void Proceed()
        {

        }
        public void PlayDemo()
        {

        }
        public void Pause()
        {
            
        }
        public void Died()
        {

        }
        public void GameOver()
        {

        }
    }
}