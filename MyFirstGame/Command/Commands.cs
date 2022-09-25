using Microsoft.Xna.Framework.Graphics;
using Sprint0.interfaces;
using Sprint0.Sprites;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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






    public abstract class NmNaCommand : ICommand
    {
        protected NmNaSprite receiver;

        protected NmNaCommand(NmNaSprite receiver)
        {
            this.receiver=receiver; 
        }

        public abstract void Execute();
    }

    public abstract class NmACommand : ICommand
    {
        protected NmASprite receiver;

        protected NmACommand(NmASprite receiver)
        {
            this.receiver = receiver;
        }

        public abstract void Execute();
    }

    public abstract class MNaCommand : ICommand
    {
        protected MNaSprite receiver;

        protected MNaCommand(MNaSprite receiver)
        {
            this.receiver = receiver;
        }

        public abstract void Execute();
    }

    public abstract class MACommand : ICommand
    {
        protected MASprite receiver;

        protected MACommand(MASprite receiver)
        {
            this.receiver = receiver;
        }

        public abstract void Execute();
    }

}







