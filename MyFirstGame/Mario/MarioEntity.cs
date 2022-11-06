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
using Sprint0.Interfaces;
using System.Security.Cryptography;
using System.ComponentModel.Design.Serialization;
using Sprint0.Enemy.EnemyState;

namespace Sprint0.Mario
{
    public class MarioEntity   : Entity, IMovableEntity
    {

        public IMarioPowerState currentPowerState { get; set; }
        public IMarioMotionState currentMotionState { get; set; }




        public  MarioFactory MarioFactory = MarioFactory.Instance;

        List<Entity> fireballPool = new List<Entity>();

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
            return type;
        }



        public MarioEntity(Game1 game, Vector2 position)
            : base(game, position)
        {
            currentMotionState = new IdleState(this);
            currentPowerState = new NormalState(this);
            Sprite = MarioFactory.CreateMario(game, position, generateType(currentMotionState, currentPowerState));
            onGround = false;
        }

        //public override void CollisionResponse(Entity entity, Vector2 position, CollisionDetector.Touching touching)
        //{
        //    //Debug.WriteLine("mario position top left: " + (Position.Y - Sprite.FrameSize.Y));
        //    //Debug.WriteLine("before update position: " + this.Position);

        //    this.Position = position;
        //    //Debug.WriteLine("after update position: " + this.Position);
        //    switch (entity)
        //    {
        //        case BlockEntity block:
        //            if (block.IsVisible)
        //            {
        //                if (touching is CollisionDetector.Touching.bottom)
        //                {
        //                    onGround = true;
        //                    currentMotionState.Fall();
        //                }
        //                else if(touching is CollisionDetector.Touching.top)
        //                {
        //                    Speed = new Vector2(Speed.X, -Speed.Y);
        //                }
        //                else
        //                {
        //                    currentMotionState.Idle();
        //                }
        //            }
        //            break;
        //        case ItemEntity:
        //            switch (entity)
        //            {
        //                case FireFlowerEntity:
        //                    if (currentPowerState.GetType() == typeof(SuperState))
        //                    {
        //                        currentPowerState.Fire();
        //                    }
        //                    if (currentPowerState.GetType() == typeof(NormalState))
        //                    {
        //                        currentPowerState.Super();
        //                    }
        //                    break;
        //                case OneUpMushroomEntity:

        //                    break;
        //                case CoinEntity:

        //                    break;
        //                case SuperMushroomEntity:
        //                    if (currentPowerState.GetType() == typeof(NormalState))
        //                        currentPowerState.Super();
        //                    break;
        //                case StarEntity:
        //                    //turn to star mario 
        //                    break;
        //                case PipeEntity:
        //                    if (touching is CollisionDetector.Touching.bottom)
        //                    {
        //                        onGround = true;
        //                        currentMotionState.Fall();
        //                    }
        //                    break;

        //            }
        //            break;
        //        case EnemyEntity:
        //            switch (entity)
        //            {
        //                case GoombaEntity:
        //                    if (touching == CollisionDetector.Touching.right || touching == CollisionDetector.Touching.left)
        //                    {
        //                        Position = position;
        //                        currentMotionState.Idle();
        //                        currentPowerState.TakeDamage();
        //                    }
        //                    else
        //                    {
        //                        currentMotionState.Fall();
        //                    }
        //                    break;
        //                case KoopaTroopaEntity:
        //                    //KoopaTroopaEntity koopa = (KoopaTroopaEntity)entity;
        //                    //Debug.WriteLine(koopa.currentState.ToString());

        //                    //if (koopa.currentState is KoopaTroopaDeathState )
        //                    //{
        //                    //    if (touching != CollisionDetector.Touching.none && touching != CollisionDetector.Touching.bottom)
        //                    //    {
        //                    //        Debug.WriteLine("DEBUG");
        //                    //        Position = position;
        //                    //        Idle();
        //                    //    }
        //                    //    else
        //                    //    {
        //                    //        Fall();
        //                    //    }
        //                    //}
        //                    //else
        //                    //{
        //                    if (touching != CollisionDetector.Touching.bottom && touching != CollisionDetector.Touching.none && touching != CollisionDetector.Touching.top)
        //                    {
        //                        Debug.WriteLine("DEBUG - 2");
        //                        Position = position;
        //                        currentMotionState.Idle();
        //                    }
        //                    else if (touching != CollisionDetector.Touching.bottom)
        //                    {
        //                        Position = new Vector2(position.X, position.Y + 5);
        //                        currentMotionState.Idle();
        //                    }
        //                    else
        //                    {
        //                        currentMotionState.Fall();
        //                    }
        //                    //}

        //                    break;
        //            }
        //            break;
        //    }
        //}

        public override void CollisionResponse(Entity entity, Vector2 position, CollisionDetector.Touching touching)
        {
            currentMotionState.CollisionResponse(entity, position, touching);
            currentPowerState.CollisionResponse(entity, position, touching);
        }


        public override void Update(GameTime gameTime, List<Entity> entities)
        {

            base.Update(gameTime, entities);

            currentMotionState?.Update(gameTime);       
            currentPowerState?.Update(gameTime);

            if(Position.Y> 480)
            {
                currentPowerState.TakeDamage();
                Speed = Vector2.Zero;
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
        }




 //----------------------------------------Motion Command Method-----------------------------------
        
        public void initalizeFireballPool()
        {
            FireballEntity fireball = new FireballEntity(game, Position,fireballPool);
            while(fireballPool.Count < 2)
            {
                fireballPool.Add(fireball);
            }
        }
        public void ShootingFireball()
        {
            if (currentPowerState is FireState) { 
            FireballEntity fireball = new FireballEntity(game, Position,fireballPool);
                if (fireballPool.Count > 0)
                {
                    EntityStorage.Instance.movableAdd(fireball);
                    fireballPool.RemoveAt(0);
                }
            }
        }

        //-------------------------------------------Power Command Method--------------------------------
    }
}
