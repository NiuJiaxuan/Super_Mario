using Sprint0.State;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Sprites;
using Sprint0.Sprites.factory;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Block.State
{
    class BrickBlockBreakState : BlockStates
    {
        public BrickBlockBreakState(BlockEntity block)
            : base(block)
        {           
        }

        public override void Enter(IBlockState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
            Block.SmallBlock1 = Block.BlockFactory.CreateBlock(Block.game, Block.Position, (int)BlockSpriteFactory.eBlockType.SmallBrickBlock);
            Block.SmallBlock2 = Block.BlockFactory.CreateBlock(Block.game, new Vector2(Block.Position.X + 25 ,Block.Position.Y), (int)BlockSpriteFactory.eBlockType.SmallBrickBlock);
            Block.SmallBlock3 = Block.BlockFactory.CreateBlock(Block.game, new Vector2(Block.Position.X, Block.Position.Y - 25), (int)BlockSpriteFactory.eBlockType.SmallBrickBlock);
            Block.SmallBlock4 = Block.BlockFactory.CreateBlock(Block.game, new Vector2(Block.Position.X + 25, Block.Position.Y - 25), (int)BlockSpriteFactory.eBlockType.SmallBrickBlock);
            Block.breakBlockVisible = false;
            
            
        }



        public override void Update(GameTime gameTime)
        {
            Block.SmallBlock1.Position = new Vector2(Block.SmallBlock1.Position.X , Block.SmallBlock1.Position.Y +10);
            Block.SmallBlock2.Position = new Vector2(Block.SmallBlock2.Position.X , Block.SmallBlock2.Position.Y +10);
            Block.SmallBlock3.Position = new Vector2(Block.SmallBlock3.Position.X, Block.SmallBlock3.Position.Y + 10);
            Block.SmallBlock4.Position = new Vector2(Block.SmallBlock4.Position.X , Block.SmallBlock4.Position.Y + 10);

            if (Block.SmallBlock2.Position.Y > 500)
            {
                EntityStorage.Instance.EntityList.Remove(Block);
            }

        }
    }
}
