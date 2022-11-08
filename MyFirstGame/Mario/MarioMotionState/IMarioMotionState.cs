using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.CollisionDetection;
using Sprint0.Mario.MarioPowerState;
using Sprint0.Sprites;

namespace Sprint0.Mario.MarioMotionState
{
    public interface IMarioMotionState
    {
        
        IMarioMotionState PreviousState { get; }
        void Enter(IMarioMotionState state);
        void Exit();
        void JumpTransion();
        void WalkTransion();
        void IdleTransion();
        void CrouchTransion();
        void FallTransion();
        void Update(GameTime gameTime);

        void Jump();
        void WalkRight();
        void WalkLeft();
        void Idle();
        void Crouch();
        void Fall();


        void CollisionResponse(Entity entity, Vector2 position, CollisionDetector.Touching touching);
       
    }
}
