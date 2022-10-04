using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controller;
using Sprint0.interfaces;
using Sprint0.Sprites;
using Sprint0.State;
using Sprint0.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using Sprint0.Mario.MarioMotionState;
using Sprint0.Mario.MarioPowerState;

namespace Sprint0.Mario
{
    public class MarioEntity   : Entity
    {

        public IMarioPowerState currentPowerState { get; set; }
        public IMarioMotionState currentMotionState { get; set; }



        private Sprite marioSprite;


        public enum eMarioType
        {
            DeadMario = 0x0000,

            NormalIdleMario = 0x0001,
            NormalWalkMario = 0x0002,
            NormalJumpMario = 0x0003,
            NormalCrouchMario = 0x0004,

            FireIdleMario = 0x0010,
            FireWalkMario = 0x0020,
            FireJumpMario = 0x0030,
            FireCrouchMario = 0x0040,

            SuperIdleMario = 0x0100,
            SuperWalkMario = 0x0200,
            SuperJumpMario = 0x0300,
            SuperCrouchMario = 0x0400,
        }

        public eMarioType marioType { get; set; }

        public int generateType(IMarioMotionState motionState, IMarioPowerState powerState)
        {
            int type = 0x0000;
            switch (motionState)
            {
                case IdleState:
                    type = 0x0001;
                    break;
                case WalkState:
                    type = 0x0002;
                    break;
                case JumpState:
                    type = 0x0003;
                    break;
                case CrouchState:
                    type = 0x0004;
                    break;
            }
            switch (powerState)
            {
                case NormalState:
                    type = type << 1;
                    break;
                case FireMario:
                    type = type << 2;
                    break;
                case SuperMario:
                    type = type << 3;
                    break;
                case DeadMario:
                    type = 0x000;
                    break;
            }

            return type;
        }

        



        public MarioEntity(Game1 game, Vector2 position)
            : base(game, position)
        {
            currentMotionState = new IdleState(this);
            currentPowerState = new NormalState(this);
        }


        public override void Update(GameTime gameTime)
        {            
            marioSprite.Update(gameTime);

            Speed += Accelation * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            currentPowerState?.Update(gameTime);
            currentMotionState?.Update(gameTime);
        }

        public override void Draw(SpriteBatch batch)
        {
            marioSprite.Draw(batch);
        }

 //----------------------------------------Motion Command Method-----------------------------------
        public void Jump()
        {
            currentMotionState?.JumpTransion();
        }

        public void Idle()
        {
            currentMotionState?.IdleTransion();
        }

        public void Walk()
        {
            currentMotionState?.WalkTransion();
        }
        public void Crouch()
        {
            currentMotionState?.CrouchTransion();
        }

//-------------------------------------------Power Command Method--------------------------------

        public void Fire()
        {
            currentPowerState?.FireTransion();
        }
        public void Normal()
        {
            currentPowerState?.NormalTransion();
        }
        public void Super()
        {
            currentPowerState?.SuperTransion();
        }
        public void Dead()
        {
            currentPowerState?.DeadTransion();
        }
    }
}
