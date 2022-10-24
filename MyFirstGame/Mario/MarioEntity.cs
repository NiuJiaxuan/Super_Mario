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
using Sprint0.State;
using Sprint0.Enemy;
using Microsoft.VisualBasic;
using Sprint0.CollisionDetection;
using Sprint0.Item;

namespace Sprint0.Mario
{
    public class MarioEntity   : Entity
    {

        public IMarioPowerState currentPowerState { get; set; }
        public IMarioMotionState currentMotionState { get; set; }




        public  MarioFactory MarioFactory = MarioFactory.Instance;



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
            //Debug.WriteLine(type);

            return type;
        }



        public MarioEntity(Game1 game, Vector2 position)
            : base(game, position)
        {
            currentMotionState = new IdleState(this);
            currentPowerState = new NormalState(this);
            //Debug.WriteLine(currentPowerState.ToString());
            //Debug.WriteLine(currentMotionState.ToString());
            Sprite = MarioFactory.CreateMario(game, position, generateType(currentMotionState, currentPowerState));
        }

        //public void blockcollisiondetection(list<entity> entities)
        //{
        //    tuple<collisiondetector.touching, float, float, entity> detected = collisiondetection.collsion(entities);

        //    if (detected.item1 != collisiondetector.touching.none)
        //    {
        //        idle();
        //        position = new vector2(detected.item2, detected.item3);
        //        //if((detected.item1 == collision.touching.top) && ())
        //    }
        //}


        //public void itemcollisiondetection(list<entity> entities)
        //{
        //    tuple<collisiondetector.touching, float, float, entity> detected = collisiondetection.collsion(entities);
        //    if (detected.item1 != collisiondetector.touching.none)
        //    {
        //        switch (detected.item4)
        //        {
        //            case fireflowerentity:
        //                if (currentpowerstate.gettype() == typeof(superstate))
        //                {
        //                    fire();
        //                }
        //                if (currentpowerstate.gettype() == typeof(normalstate))
        //                {
        //                    super();
        //                }
        //                entities.remove(detected.item4);
        //                break;
        //            case supermushroomentity:
        //                if (currentpowerstate.gettype() == typeof(normalstate))
        //                    super();
        //                entities.remove(detected.item4);
        //                break;
        //            case pipeentity:
        //                if (detected.item1 != collisiondetector.touching.none)
        //                {
        //                    idle();
        //                    position = new vector2(detected.item2, detected.item3);
        //                }
        //                break;
        //        }
        //    }
        //}

        //public void enemycollisiondetection(list<entity> entities)
        //{
        //    tuple<collisiondetector.touching, float, float, entity> detected = collisiondetection.collsion(entities);

        //    if (detected.item1 != collisiondetector.touching.bottom && detected.item1 != collisiondetector.touching.none)
        //    {
        //        position = new vector2(detected.item2, detected.item3);
        //        idle();
        //        takedamage();
        //    }
        //    else if (detected.item1 == collisiondetector.touching.bottom)
        //    {
        //        //debug.writeline("touch from top");
        //        position = new vector2(detected.item2, detected.item3);
        //        idle();
        //    }
        //}

        public override void CollisionResponse(Entity entity, Vector2 position, CollisionDetector.Touching touching)
        {
            switch (entity)
            {
                case BlockEntity:
                    if(touching == CollisionDetector.Touching.top)
                    {
                        Idle();
                        this.Position = position;
                    }else if(touching != CollisionDetector.Touching.none)
                    {
                        if (entity.IsVisible)
                        {
                            Idle();
                            this.Position = position;
                        }
                    }
                    break;
                case ItemEntity:
                    switch (entity)
                    {
                        case FireFlowerEntity:
                            if (currentPowerState.GetType() == typeof(SuperState))
                            {
                                Fire();
                            }
                            if (currentPowerState.GetType() == typeof(NormalState))
                            {
                                Super();
                            }
                            break;
                        case OneUpMushroomEntity:

                            break;
                        case CoinEntity:

                            break;
                        case SuperMushroomEntity:
                            if (currentPowerState.GetType() == typeof(NormalState))
                                Super();
                            break;
                        case StarEntity:
                            //turn to star mario 
                            break;
                    }
                    break;
                case EnemyEntity:
                    switch (entity)
                    {
                        case GoombaEntity:
                            if(touching != CollisionDetector.Touching.bottom && touching != CollisionDetector.Touching.none)
                            {
                                Position = position;
                                Idle();
                                TakeDamage();
                            }
                            break;
                        case KoopaTroopaEntity:

                            break;
                    }
                    break;
            }
        }


        public override void Update(GameTime gameTime, List<Entity> entities)
        {

            base.Update(gameTime, entities);

            Speed += Accelation * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //Debug.WriteLine("speed is " + Speed);
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

        //the vertical and horizontal speed after state change will turn to zero
        //need to fix this problem later
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
                        currentMotionState?.IdleTransion();
                    }
                    break;
                case CrouchState:
                    if (Sprite.Orientation == SpriteEffects.None)
                    {
                        currentMotionState?.IdleTransion();
                    }
                    else
                    {
                        Sprite.Orientation = SpriteEffects.None;
                        currentMotionState?.IdleTransion();
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
                        currentMotionState?.IdleTransion();
                    }
                    break;
                case CrouchState:
                    if (Sprite.Orientation == SpriteEffects.FlipHorizontally)
                    {
                        currentMotionState?.IdleTransion();
                    }
                    else
                    {
                        Sprite.Orientation = SpriteEffects.FlipHorizontally;
                        currentMotionState?.IdleTransion();
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
                   // if(currentPowerState.GetType() != typeof(NormalState))
                        currentMotionState?.CrouchTransion();
                    break;
            }
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
