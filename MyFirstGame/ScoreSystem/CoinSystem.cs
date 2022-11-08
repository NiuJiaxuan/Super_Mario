using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.ScoreSystem
{
    public class CoinSystem
    {
        public int CoinCount { get; set; }

        private static CoinSystem instance;

        public static CoinSystem Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new CoinSystem();
                }
                return instance;
            }
        }

        public CoinSystem()
        {
            CoinCount = 0;
        }
        public void resetCoin()
        {
            CoinCount = 0;
        }

        public void GainOneCoin()
        {
            CoinCount++;
            if (CoinCount == 100)
            {
                LifeSystem.Instance.GainOneLife();
                CoinReset();
            }
        }
        public void CoinReset()
        {
            CoinCount = 0;
        }

    }
}
