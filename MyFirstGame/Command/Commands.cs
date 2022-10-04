using Microsoft.Xna.Framework.Graphics;
using Sprint0.interfaces;
using Sprint0.Sprites;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Mario;

namespace Sprint0.Command
{
    public abstract class GameCommand : ICommand
    {
        protected Game1 receiver;

        protected GameCommand(Game1 receiver)
        {
            this.receiver = receiver;
        }

        public abstract void Execute();

    }


    public abstract class MarioCommand : ICommand
    {
        protected MarioEntity receiver;
        protected MarioCommand(MarioEntity receiver)
        {
            this.receiver = receiver;
        }
        public abstract void Execute();
    }


}







