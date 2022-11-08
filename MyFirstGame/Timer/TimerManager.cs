using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Timers
{
    public  class TimerManager
    {
        private bool removeAll = false;
        private List<ITimer> timers = new List<ITimer>(); 
        private List<ITimer> timerInsertQueue = new List<ITimer>();
        private List<ITimer> timerRemovalQueue = new List<ITimer>();


        private static TimerManager instance;
        public static TimerManager Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new TimerManager();

                }
                return instance;
            }
        }
        public TimerManager()
        {

        }
        public void AddToTimerList(ITimer timer)
        {
            timerInsertQueue.Add(timer);
        }
        public void AddTimers()
        {
            foreach (ITimer timer in timerInsertQueue)
            {
                timers.Add(timer);
            }
            timerInsertQueue.Clear();
        }


        public void RemoveFromTimerList(ITimer timer)
        {
            timerRemovalQueue.Add(timer);
        }
        public void RemoveTimers()
        {

            foreach (ITimer timer in timerRemovalQueue)
            {
                timers.Remove(timer);
            }

            timerRemovalQueue.Clear();
        }

        public void RemoveAllTimers()
        {
            removeAll = true;
        }


        public void Update(GameTime gameTime)
        {
            AddTimers();
            foreach (ITimer timer in timers)
            {
                if (removeAll)
                    break;
                timer.Update(gameTime);
            }
            if (removeAll)
            {
                timerRemovalQueue.Clear();
                timers.Clear();
                removeAll = false;
            }
            RemoveTimers();
        }

    }
}
