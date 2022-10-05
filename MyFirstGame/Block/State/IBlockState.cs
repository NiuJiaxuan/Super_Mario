using Microsoft.Xna.Framework;
using Sprint0.Mario.MarioMotionState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Block.State
{
    public interface IBlockState
    {
        IBlockState PreviousState { get; }
        void Enter(IBlockState previousState);
        void Exit();
        void Update(GameTime gameTime);
        void NormalTransition();
        void BumpTransition();
        void UsedTransition();
        void BreakTransition();
    }
}
