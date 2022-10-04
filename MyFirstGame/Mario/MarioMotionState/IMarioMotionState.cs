using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Mario.MarioPowerState;
using Sprint0.Sprites;

namespace Sprint0.Mario.MarioMotionState
{
    public interface IMarioMotionState
    {
        
        IMarioMotionState PreviousState { get; }
        IMarioPowerState PowerState { get; }
        void Enter(IMarioMotionState state);
        void Exit();
        void JumpTransion();
        void WalkTransion();
        void IdleTransion();
        void CrouchTransion();
        void Update(GameTime gameTime);
        
        

    }
}
