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
            LifeCount = 0;
        }

        public void InitializeLife(int numOfLives)
        {
            LifeCount = numOfLives;
        }
        public void GainOneLife()
        {
            LifeCount++;
        }
        public void LoseOneLife()
        {
            if (LifeCount > 0)
            {
                LifeCount--;
            }
            else
            {
                //game over
            }
        }

    }
}
