using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controller;
using Sprint0.interfaces;
using Sprint0.Sprites;
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
using Sprint0.Sprites.factory;
using Sprint0.Block;

namespace Sprint0.Mario
{
    public class MarioEntity   : Entity
    {

        public IMarioPowerState currentPowerState { get; set; }
        public IMarioMotionState currentMotionState { get; set; }




        public virtual  MarioFactory MarioFactory => game.MarioFactory;



        public enum eMarioType
        {
            DeadMario = 0,

            NormalIdleMario = 1,
            NormalWalkMario = 2,
            NormalJumpMario = 3,
            NormalCrouchMario = 4,

            FireIdleMario = 11,
            FireWalkMario = 12,
            FireJumpMario = 13,
            FireCrouchMario = 14,

            SuperIdleMario = 21,
            SuperWalkMario = 22,
            SuperJumpMario = 23,
            SuperCrouchMario = 24,
        }

        public int marioType { get; set; }

        public int generateType(IMarioMotionState motionState, IMarioPowerState powerState)
        {
            int type = 0;
            switch (motionState)
            {
                case IdleState:
                    type = 1;
                    break;
                case WalkState:
                    type = 2;
                    break;
                case JumpState:
                    type = 3;
                    break;
                case CrouchState:
                    type = 4;
                    break;
            }
            switch (powerState)
            {
                case NormalState: 
                    type +=0;
                    break;
                case FireState:
                    type +=10;
                    break;
                case SuperState:
                    type +=20;
                    break;
                case DeadState:
                    type = 0;
                    break;
            }
            Debug.WriteLine(type);

            return type;
        }





        public MarioEntity(Game1 game, Vector2 position)
            : base(game, position)
        {
            currentMotionState = new IdleState(this);
            currentPowerState = new NormalState(this);
            Debug.WriteLine(currentPowerState.ToString());
            Debug.WriteLine(currentMotionState.ToString());
            Sprite = MarioFactory.CreateMario(game, position, generateType(currentMotionState, currentPowerState));

        }

/*         public void CollisionDetection (Sprite currentRectangular, List<Entity> entities)
        {
            foreach ( Entity entity in entities)
            {
                switch (entity){
                    case BrickBlockEntity:
                        if (isTouchingLeft(entity) || isTouchingRight(entity))
                        {
                            currentMotionState?.IdleTransion();
                            Speed = new Vector2(0, Speed.Y);
                        }//           fix later
                        break;
                }
            }



        }
*/
        public override void Update(GameTime gameTime/*, List<Entity> entities*/)
        {
 //           CollisionDetection(Sprite, entities);

            base.Update(gameTime/*, entities*/);

            Speed += Accelation * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            currentPowerState?.Update(gameTime);
            currentMotionState?.Update(gameTime);
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
        }

 //----------------------------------------Motion Command Method-----------------------------------
        public void Jump()
        {
            switch (currentMotionState)
            {
                case CrouchState:
                    currentMotionState?.IdleTransion();
                    break;
                default:
                    currentMotionState?.JumpTransion();
                    break;
            }
        }

        public void Idle()
        {
            currentMotionState?.IdleTransion();
        }

        public void WalkRight()
        {
            switch (currentMotionState)
            {
                case IdleState:
                    if (Sprite.Orientation == SpriteEffects.None)
                    {
                        currentMotionState?.WalkTransion();
                    }else
                    {
                        Sprite.Orientation = SpriteEffects.None;
                    }
                    break;
                case WalkState:
                    if(Sprite.Orientation == SpriteEffects.FlipHorizontally)
                    {
                        currentMotionState?.IdleTransion();
                    }
                    break;
                case JumpState:
                    if (Sprite.Orientation == SpriteEffects.None)
                    {
                        currentMotionState?.WalkTransion();
                    }
                    else
                    {
                        Sprite.Orientation = SpriteEffects.None;
                    }
                    break;
            }

        }
        public void WalkLeft()
        {
            switch (currentMotionState)
            {
                case IdleState:
                    if (Sprite.Orientation == SpriteEffects.FlipHorizontally)
                    {
                        currentMotionState?.WalkTransion();
                    }
                    else
                    {
                        Sprite.Orientation = SpriteEffects.FlipHorizontally;
                    }
                    break;
                case WalkState:
                    if (Sprite.Orientation == SpriteEffects.None)
                    {
                        currentMotionState?.IdleTransion();
                    }
                    break;
                case JumpState:
                    if (Sprite.Orientation == SpriteEffects.FlipHorizontally)
                    {
                        currentMotionState?.WalkTransion();
                    }
                    else
                    {
                        Sprite.Orientation = SpriteEffects.FlipHorizontally;
                    }
                    break;
            }
        }
        public void Crouch()
        {
            switch (currentMotionState)
            {
                case JumpState:
                    currentMotionState?.IdleTransion();
                    break;
                default:
                    if(currentPowerState.GetType() != typeof(NormalState))
                        currentMotionState?.CrouchTransion();
                    break;
            }
        }
        public void FaceRight()
        {
            Sprite.Orientation = SpriteEffects.None;

        }
        public void FaceLeft()
        {
            Sprite.Orientation = SpriteEffects.FlipHorizontally;

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
        public void TakeDamage()
        {
            switch (currentPowerState)
            {
                case NormalState:
                    currentPowerState?.DeadTransion();
                    break;
                case SuperState:
                    currentPowerState?.NormalTransion();
                    break;
                case FireState:
                    currentPowerState?.SuperTransion();
                    break;
            }
        }
    }
}
