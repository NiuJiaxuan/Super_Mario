using Sprint0.State;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Mario.MarioPowerState;
using Sprint0.Mario;
using Sprint0.Sprites.factory;
using Sprint0.Sprites;

namespace Sprint0.Block.State
{
    class BrickBlockNormalState : BlockStates
    {

        public BrickBlockNormalState(BlockEntity block)
            : base(block)
        {
        }
        public MarioEntity Mario { get; set; }

        public override void Enter(IBlockState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;

            Vector2 Origion = Vector2.Zero;
            if (Block.Sprite != null)
            {
                Origion = Block.Position;
            }
            
            Block.Sprite = Block.BlockFactory.CreateBlock(Block.game, Block.Position, (int)BlockSpriteFactory.eBlockType.BrickBlock);
            Block.BlockType = BlockEntity.eBlockType.BrickBlock;
            Block.Position = Origion;

        }
        
        public override void BumpTransition()
        {
            CurrentState.Exit();
            CurrentState = new BrickBlockBumpState(Block);
            CurrentState.Enter(this);
        }
        public override void BreakTransition()
        {
            CurrentState.Exit();
            CurrentState = new BrickBlockBreakState(Block);
            CurrentState.Enter(this);
            
        }
    }
}
