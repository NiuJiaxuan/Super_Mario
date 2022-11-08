using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.ScoreSystem
{
    public class ScoreSystemManager
    {
        public long Score { get; set; }
        public static int CoinCount => CoinSystem.Instance.CoinCount;
        public static int LifeCount => LifeSystem.Instance.LifeCount;
        private static ScoreSystemManager instance;
        public static ScoreSystemManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScoreSystemManager();
                }
                return instance;
            }
        }
        public ScoreSystemManager()
        {
            Score = 0;
        }
        public void Coin()
        {
            Score += 200;
            CoinSystem.Instance.GainOneCoin();
        }
        public void SuperMushroom()
        {
            Score += 1000;
        }
        public void FireFlower()
        {
            Score += 1000;
        }
        public void OneUpMushroom()
        {
            LifeSystem.Instance.GainOneLife();
        }
        public void KillGoomba()
        {
            Score += 100;
        }
        public void KillTroopa()
        {
            Score += 100;
        }
        public void Star()
        {
            Score += 1000;
        }
        public void ResetScore()
        {
            Score = 0;
        }
    }
}
