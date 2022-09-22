using Microsoft.Xna.Framework.Graphics;
using MyFirstGame.interfaces;
using MyFirstGame.Sprites;
using sprint0;
using Sprint0.Sprites;
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







