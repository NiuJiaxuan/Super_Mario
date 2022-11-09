using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Block;
using Sprint0.CollisionDetection;
using Sprint0.Enemy;
using Sprint0.interfaces;
using Sprint0.Item;
using Sprint0.level;
using Sprint0.Mario.MarioPowerState;
using Sprint0.Sprites;
using Sprint0.State;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Mario.MarioMotionState
{
    public abstract class MarioMotionState : IMarioMotionState
    {
        protected IMarioMotionState previousState;

        protected IMarioPowerState PowerState { get { return Mario.currentPowerState; } }

        public MarioEntity Mario;
        List<Entity> temp1;
        List<Entity> temp2;

        protected IMarioMotionState CurrentState { get { return Mario.currentMotionState; } set { Mario.currentMotionState = value; } }
        IMarioMotionState IMarioMotionState.PreviousState { get { return previousState; } }
  
        

        protected MarioMotionState(MarioEntity mario)
        {
            Mario = mario;
        }

        public virtual void Enter(IMarioMotionState state)
        {
            CurrentState = this;
            this.previousState = state;
        }

        public virtual void Exit() { }

        public virtual void JumpTransion() { }
        public virtual void WalkTransion() { }
        public virtual void IdleTransion() { }
        public virtual void CrouchTransion() { }
        public virtual void FallTransion() { }

        public virtual void Update(GameTime gameTime) { }

        public void Jump()
        {
            if (!(Mario.currentPowerState is DeadState))
            {
                switch (this)
                {
                    case CrouchState:
                        this?.IdleTransion();
                        break;
                    default:
                        this?.JumpTransion();
                        break;
                }
            }
        }

        public void Idle()
        {
            this?.IdleTransion();
        }

        public void Fall()
        {
            this?.FallTransion();
        }
        //the vertical and horizontal speed after state change will turn to zero
        //need to fix this problem later
        public void WalkRight()
        {
            if (!(Mario.currentPowerState is DeadState))
            {
                switch (this)
                {
                    case IdleState:
                        if (Mario.Sprite.Orientation == SpriteEffects.None)
                        {
                            this?.WalkTransion();
                        }
                        else
                        {
                            Mario.Sprite.Orientation = SpriteEffects.None;
                        }
                        break;
                    case WalkState:
                        if (Mario.Sprite.Orientation == SpriteEffects.FlipHorizontally)
                        {
                            this?.IdleTransion();
                        }
                        break;
                    case JumpState:
                        if (Mario.Sprite.Orientation == SpriteEffects.None)
                        {
                            Mario.Speed += new Vector2(40, 0);
                        }
                        else
                        {
                            Mario.Sprite.Orientation = SpriteEffects.None;
                            this?.IdleTransion();
                        }
                        break;
                    case CrouchState:
                        if (Mario.Sprite.Orientation == SpriteEffects.None)
                        {
                            this?.IdleTransion();
                        }
                        else
                        {
                            Mario.Sprite.Orientation = SpriteEffects.None;
                            this?.IdleTransion();
                        }
                        break;
                }
            }


        }
        public void WalkLeft()
        {
            if (!(Mario.currentPowerState is DeadState))
            {
                switch (this)
                {
                    case IdleState:
                        if (Mario.Sprite.Orientation == SpriteEffects.FlipHorizontally)
                        {
                            this?.WalkTransion();
                        }
                        else
                        {
                            Mario.Sprite.Orientation = SpriteEffects.FlipHorizontally;
                        }
                        break;
                    case WalkState:
                        if (Mario.Sprite.Orientation == SpriteEffects.None)
                        {
                            this?.IdleTransion();
                        }
                        break;
                    case JumpState:
                        if (Mario.Sprite.Orientation == SpriteEffects.FlipHorizontally)
                        {
                            Mario.Speed += new Vector2(-40, 0);
                        }
                        else
                        {
                            Mario.Sprite.Orientation = SpriteEffects.FlipHorizontally;
                            this?.IdleTransion();
                        }
                        break;
                    case CrouchState:
                        if (Mario.Sprite.Orientation == SpriteEffects.FlipHorizontally)
                        {
                            this?.IdleTransion();
                        }
                        else
                        {
                            Mario.Sprite.Orientation = SpriteEffects.FlipHorizontally;
                            this?.IdleTransion();
                        }
                        break;
                }
            }
        }
        public void Crouch()
        {
            if (!(Mario.currentPowerState is DeadState))
            {
                switch (this)
                {
                    case JumpState:
                        this?.IdleTransion();
                        break;
                    case WalkState:
                        this?.IdleTransion();
                        break;
                    default:
                        // if(currentPowerState.GetType() != typeof(NormalState))
                        this?.CrouchTransion();
                        break;
                }
            }
        }


        public void CollisionResponse(Entity entity, Vector2 position, CollisionDetector.Touching touching)
        {
            Mario.Position = position;
            switch (entity)
            {
                case BlockEntity:
                    if (entity.IsVisible)
                    {
                        if (touching is CollisionDetector.Touching.bottom)
                        {
                            Mario.onGround = true;
                            Fall();
                        }
                        else if (touching is CollisionDetector.Touching.top)
                        {
                            Mario.Speed = new Vector2(Mario.Speed.X, -Mario.Speed.Y);
                        }
                        else
                        {
                            Idle();
                        }
                    }
                    switch (entity)
                    {
                        case PipeEntity pipe:
                            if(touching == CollisionDetector.Touching.bottom)
                            {
                                if (!pipe.plant)
                                {
                                    SoundStorage.Instance.PlayPipe();
                                    if (!pipe.isHiddenMap)
                                    {
                                        EntityStorage.Instance.Mario.Position = pipe.WarpPosition;
                                    }
                                    else
                                    {
                                        if (pipe.HiddenMap != "MarioLevel1.xml")
                                        {
                                            temp1 = EntityStorage.Instance.EntityList;
                                            temp2 = EntityStorage.Instance.MovableEntities;
                                            EntityStorage.Instance.MovableEntities.Clear();
                                            EntityStorage.Instance.EntityList.Clear();
                                            Mario.game.levelBuilder.LodeLevel(Mario.game, pipe.HiddenMap);
                                        }
                                        else
                                        {
                                            EntityStorage.Instance.MovableEntities.Clear();
                                            EntityStorage.Instance.EntityList.Clear();
                                            EntityStorage.Instance.EntityList = temp1;
                                            EntityStorage.Instance.MovableEntities = temp2;
                                        }
                                    }
                                }
                            }
                            break;
                    }
                    break;
                case EnemyEntity:
                    switch (entity)
                    {
                        case GoombaEntity:
                            if (touching == CollisionDetector.Touching.right || touching == CollisionDetector.Touching.left)
                            {
                                Mario.Position = position;
                                Idle();
                            }
                            else if (touching == CollisionDetector.Touching.top)
                            {
                                Fall();
                            }
                            else
                            {
                                Fall();
                            }
                            break;
                        case KoopaTroopaEntity:

                            if (touching != CollisionDetector.Touching.bottom && touching != CollisionDetector.Touching.none && touching != CollisionDetector.Touching.top)
                            {
                                Debug.WriteLine("DEBUG - 2");
                                Mario.Position = position;
                                Idle();
                                //TakeDamage();
                            }
                            else if (touching != CollisionDetector.Touching.bottom)
                            {
                                Mario.Position = new Vector2(position.X, position.Y + 5);
                                Idle();
                            }
                            else
                            {
                                Fall();
                            }

                            break;
                        case PiranhaEntity:
                            Idle();
                            if (touching == CollisionDetector.Touching.right)
                            {
                                Vector2 pos = new Vector2(Mario.Position.X - 10, Mario.Position.Y);
                                Mario.Position = pos;
                            }
                            else if (touching == CollisionDetector.Touching.left)
                            {
                                Vector2 pos = new Vector2(Mario.Position.X + 10, Mario.Position.Y);
                                Mario.Position = pos;
                            }
                            else if(touching == CollisionDetector.Touching.top)
                            {
                                Vector2 pos = new Vector2(Mario.Position.X, Mario.Position.Y + 10);
                                Mario.Position = pos;
                            }
                            break;
                    }
                    break;
                case ItemEntity:
                    if(entity is CastleEntity)
                    {
                        Idle();
                    }
                    break;
            }
        }

    }
}
