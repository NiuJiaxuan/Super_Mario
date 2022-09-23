using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.interfaces;

namespace Sprint0.Controller
{
    public abstract class Controllers : IController
    {

        protected Dictionary<int, ICommand> commands;

        public Controllers()
        {
            commands = new Dictionary<int, ICommand>();
        }

        public void Command(int key, ICommand command)
        {
            commands.Add(key, command);
        }

        public abstract void Update();
    }
}
