using Sprint0;
using Sprint0.Block;
using Sprint0.Mario;
using Sprint0.Sprites;
using Sprint0.State;
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
            receiver.Fire();
        }
    }

    public class ChangeToSuperMario : MarioCommand
    {
        public ChangeToSuperMario(MarioEntity receiver)
            : base(receiver) { }

        public override void Execute()
        {
            receiver.Super();
        }
    }

    public class ChangeToNormalMario : MarioCommand
    {
        public ChangeToNormalMario(MarioEntity receiver)
            : base(receiver) { }

        public override void Execute()
        {
            receiver.Normal();
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

    public class MarioJump : MarioCommand
    {
        public MarioJump(MarioEntity receiver)
            : base(receiver) { }

        public override void Execute()
        {
            receiver.Jump();
        }
    }

    public class MarioCrouch : MarioCommand
    {
        public MarioCrouch(MarioEntity receiver)
            : base(receiver) { }

        public override void Execute()
        {
            receiver.Crouch();
        }
    }

    public class MarioWalkRight : MarioCommand
    {
        public MarioWalkRight(MarioEntity receiver)
            : base(receiver) { }

        public override void Execute()
        {
            receiver.WalkRight();
        }
    }
    public class MarioWalkLeft : MarioCommand
    {
        public MarioWalkLeft(MarioEntity receiver)
            : base(receiver) { }

        public override void Execute()
        {
            receiver.WalkLeft();
        }
    }

    public class BlockBumpOrBreak : BrickBlockCommand
    {
        public BlockBumpOrBreak(BrickBlockEntity receiver)
            : base (receiver) { }
        public override void Execute()
        {
            receiver.BumpOrBreakTransition();
        }

    }

    public class BlockBump : BlockCommand
    {
        public BlockBump(BlockEntity receiver)
            : base(receiver) { }
        public override void Execute()
        {
            receiver.BumpTransition();
        }

    }
    public class ChangeToVisible : BrickBlockCommand
    {
        public ChangeToVisible(BrickBlockEntity receiver)
            : base(receiver) { }
        public override void Execute()
        {
            receiver.changeToVisible();
            receiver.BumpOrBreakTransition();
        }

    }

}
