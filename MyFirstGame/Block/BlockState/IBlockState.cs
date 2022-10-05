using Microsoft.Xna.Framework;
using Sprint0.Mario.MarioMotionState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Block.BlockState
{
    public interface IBlockState
    {
        IBlockState PreviousState { get; set; }

        void Enter(IBlockState state);
        void Exit();
        void Update(GameTime gameTime);

        void NormalTransition();
        void BumpTransition();
        void UsedTransition();
        void BreakTransition();
    }
}
