using Sprint0;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Command
{
    public class ExitCommand : GameCommand
    {
        public ExitCommand(Game1 receiver)
            : base(receiver) { }

        public override void Execute()
        {
            receiver.ExitCommnad();
        }
    }

    public class ShowNmNaCommand : NmNaCommand
    {
        public ShowNmNaCommand(NmNaSprite receiver)
            : base(receiver) { }

        public override void Execute()
        {
            receiver.VisibleCommand();
        }
    }

    public class ShowNmACommand : NmACommand
    {
        public ShowNmACommand(NmASprite receiver)
            : base(receiver) { }

        public override void Execute()
        {
            receiver.VisibleCommand();
        }
    }
    public class ShowMNaCommand : MNaCommand
    {
        public ShowMNaCommand(MNaSprite receiver)
            : base(receiver) { }

        public override void Execute()
        {
            receiver.VisibleCommand();
        }
    }

    public class ShowMACommand : MACommand
    {
        public ShowMACommand(MASprite receiver)
            : base(receiver) { }

        public override void Execute()
        {
            receiver.VisibleCommand();
        }
    }
}
