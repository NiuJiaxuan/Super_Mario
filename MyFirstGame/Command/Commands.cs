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
using Sprint0.State;
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
    public abstract class EntityStorageCommand : ICommand
    {
        protected EntityStorage receiver;

        protected EntityStorageCommand(EntityStorage receiver)
        {
            this.receiver = receiver;
        }

        public abstract void Execute();

    }
    public abstract class EntityCommand : ICommand
    {
        protected List<Entity> receiver;

        protected EntityCommand(List<Entity> receiver)
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

    public abstract class BlockCommand : ICommand
    {
        protected BlockEntity receiver;
        protected BlockCommand(BlockEntity receiver)
        {
            this.receiver = receiver;
        }
        public abstract void Execute();
    }
    public abstract class BrickBlockCommand : ICommand
    {
        protected BrickBlockEntity receiver;
        protected BrickBlockCommand(BrickBlockEntity receiver)
        {
            this.receiver = receiver;
        }
        public abstract void Execute();
    }


}







