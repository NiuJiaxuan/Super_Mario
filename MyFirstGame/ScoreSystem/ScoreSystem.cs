using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.ScoreSystem
{
    public class ScoreSystem
    {
        private static ScoreSystem instance;
        public static ScoreSystem Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScoreSystem();
                }
                return instance;
            }
        }
        public ScoreSystem()
        {

        }
    }
}
