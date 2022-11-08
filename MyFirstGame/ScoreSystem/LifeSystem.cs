using Sprint0.Block.State.GameState;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.ScoreSystem
{
    public class LifeSystem
    {
        public int LifeCount { get; set; }
        private static LifeSystem instance;
        public bool isNoLife = false;
        public static LifeSystem Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LifeSystem(); 
                }
                return instance;
            }
        }
        public LifeSystem()
        {
            LifeCount = 3;
        }

        public void resetLife()
        {
            LifeCount = 3;
        }
        public void InitializeLife(int numOfLives)
        {
            LifeCount = numOfLives;
        }
        public void GainOneLife()
        {
            LifeCount++;
            if (LifeCount > 0) isNoLife = false;
        }
        public void LoseOneLife()
        {
            if (LifeCount > 0)
            {
                LifeCount--;
                if (LifeCount == 0) isNoLife = true;
            }
            else
            {
                GameOverState.Instance.gameOver();
                SoundStorage.Instance.PlayGameOver();
            }
        }

    }
}
