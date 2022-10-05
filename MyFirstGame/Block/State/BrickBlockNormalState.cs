using Sprint0.State;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Sprites;

namespace Sprint0.Block.State
{
    class BrickBlockNormalState : BlockStates
    {

        public BrickBlockNormalState(BlockEntity block)
            : base(block)
        {
        }

        public override void Enter(IBlockState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;

            Vector2 Origion = Vector2.Zero;
            if (Block.Sprite != null)
            {
                Origion = Block.Position;
            }
            int type = Block.generateType(CurrentState);
            Block.Sprite = Block.BlockFactory.CreateBlock(Block.game, Block.Position, type);
            Block.blockType = type;
            Block.Position = Origion;

        }
        public override void BumpTransition()
        {
            CurrentState.Exit();
            CurrentState = new BrickBlockBumpState(Block);
            CurrentState.Enter(this);
        }
    }
}
