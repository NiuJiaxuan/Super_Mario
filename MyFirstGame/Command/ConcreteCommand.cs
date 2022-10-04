using Sprint0;
using Sprint0.Mario;
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


    public class ChangeToFireMario : MarioCommand
    {
        public ChangeToFireMario(MarioEntity receiver)
            :base(receiver) { }

        public override void Execute()
        {
            receiver.ChangeToFire();
        }
    }

    public class ChangeToSuperMario : MarioCommand
    {
        public ChangeToSuperMario(MarioEntity receiver)
            : base(receiver) { }

        public override void Execute()
        {
            receiver.ChangeToSuper();
        }
    }

    public class ChangeToNormalMario : MarioCommand
    {
        public ChangeToNormalMario(MarioEntity receiver)
            : base(receiver) { }

        public override void Execute()
        {
            receiver.ChangeToNormal();
        }
    }

    public class MarioTakeDamege : MarioCommand
    {
        public MarioTakeDamege(MarioEntity receiver)
            : base(receiver) { }

        public override void Execute()
        {
            receiver.TakeDamage();
        }
    }
}
