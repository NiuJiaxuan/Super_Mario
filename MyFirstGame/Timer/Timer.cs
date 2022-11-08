using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Timers
{
    public class Timer : ITimer
    {

        public Entity GetEntity { get; set; }

        private Action method;

        private int milliseconds;
        private int pastTime = 0;



        public Timer(int milliseconds, Action action)
        {
            Debug.WriteLine("create new timer");
            this.milliseconds = milliseconds;
            this.method = action;
        }

        public void Update(GameTime gameTime)
        {
            pastTime += gameTime.ElapsedGameTime.Milliseconds;
            if (pastTime >= milliseconds)
            {
                method();
                TimerManager.Instance.RemoveFromTimerList(this);
            }
        }

         
    }
}
