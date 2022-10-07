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
    class StairBlockNormalState : BlockStates
    {

        public StairBlockNormalState(BlockEntity block)
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

            Block.Sprite = Block.BlockFactory.CreateBlock(Block.game, Block.Position, (int)BlockSpriteFactory.eBlockType.StairBlock);
            Block.BlockType = BlockEntity.eBlockType.StairBlock;
            Block.Position = Origion;

        }
    }
}
