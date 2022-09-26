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
using Sprint0.Block;

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
        protected MarioContext receiver;
        protected MarioCommand(MarioContext receiver)
        {
            this.receiver = receiver;
        }
        public abstract void Execute();
    }

    public abstract class QuestionBlockCommand : ICommand
    {
        protected QuestionBlock receiver;
        protected QuestionBlockCommand(QuestionBlock receiver)
        {
            this.receiver = receiver;
        }
        public abstract void Execute();
    }
    public abstract class BrickBlockCommand : ICommand
    {
        protected BrickBlock receiver;
        protected BrickBlockCommand(BrickBlock receiver)
        {
            this.receiver = receiver;
        }
        public abstract void Execute();
    }


}







