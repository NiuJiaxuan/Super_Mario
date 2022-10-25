using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        void BumpTransition(int count);
        void UsedTransition();
        void BreakTransition();
        void EmptyTransition();
    }
}
