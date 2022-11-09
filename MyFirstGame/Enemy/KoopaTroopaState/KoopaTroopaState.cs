using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Block;
using Sprint0.CollisionDetection;
using Sprint0.Enemy.EnemyState;
using Sprint0.Item;
using Sprint0.Mario;
using Sprint0.Sprites;

namespace Sprint0.Enemy.KoopaTroopaStates
{
    //Ben Changes
    public class KoopaTroopaState : IEnemyState
    {
        protected IEnemyState previousState;
        IEnemyState IEnemyState.PreviousState { get { return previousState; } }
        protected IEnemyState CurrentState { get { return Enemy.currentState; } set { Enemy.currentState = value; } }
        public bool isRemoved = false;

        public EnemyEntity Enemy;
        protected KoopaTroopaState(EnemyEntity enemy)
        {
            Enemy = enemy;
        }


        public virtual void Update(GameTime gameTime) { }
        public virtual void DeadTransition(bool isBump) { }
        public virtual void Enter(IEnemyState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
        }
        public virtual void Exit() { }
        public virtual void EmergeTransition() { }

        public virtual void KillTransition() { }

        public virtual void NormalTransition(string dir) { }

        public virtual void ShellTransition() { }
        public virtual void ShellMovingTransition(string dir) { }
        public virtual void EmergeTransition(string dir) { }



        public void ChangeDirection(CollisionDetector.Touching touching)
        {

            if(Enemy.Orientation is SpriteEffects.None && touching == CollisionDetector.Touching.left)
            {
                Enemy.Orientation = SpriteEffects.FlipHorizontally;
            }
            else if(Enemy.Orientation is SpriteEffects.FlipHorizontally && touching == CollisionDetector.Touching.right)
            {
                Enemy.Orientation = SpriteEffects.None;
            }
        }

        public void TakeDamage()
        {
            if(this is KoopaTroopaNormalState)
            {
                this.ShellTransition();
            }
        }

        public void BumpLeft()
        {
            if (this is KoopaTroopaShellState)
            {
                Enemy.Orientation = SpriteEffects.None;
                this.ShellMovingTransition("left");
            }
        }

        public void BumpRight()
        {
            if(this is KoopaTroopaShellState)
            {
                Enemy.Orientation = SpriteEffects.FlipHorizontally;
                this.ShellMovingTransition("right"); 
            }
        }

        public void StopMoving()
        {
            if (this is KoopaTroopaMovingShellState)
                this.ShellTransition();
        }

        public void revive()
        {
            if (this is KoopaTroopaShellState)
                this.NormalTransition("left");
        }

        public void CollisionResponse(Entity entity, Vector2 position, CollisionDetector.Touching touching)
        {
            switch (entity)
            {
                case MarioEntity:
                    switch (this)
                    {
                        case KoopaTroopaNormalState:
                            switch (touching)
                            {
                                case CollisionDetector.Touching.top:
                                    this.TakeDamage();
                                    break;
                                case CollisionDetector.Touching.right:
                                    this.ChangeDirection(touching);
                                    (entity as MarioEntity).currentPowerState.TakeDamage();
                                    break;
                                case CollisionDetector.Touching.left:
                                    this.ChangeDirection(touching);
                                    (entity as MarioEntity).currentPowerState.TakeDamage();
                                    break;
                            }
                            break;
                        case KoopaTroopaShellState:
                            switch (touching)
                            {
                                case CollisionDetector.Touching.top:
                                    break;
                                case CollisionDetector.Touching.right:
                                    this.BumpLeft();
                                    break;
                                case CollisionDetector.Touching.left:
                                    this.BumpRight();
                                    break;
                            }
                            break;
                        case KoopaTroopaMovingShellState:
                            switch (touching)
                            {
                                case CollisionDetector.Touching.top:
                                    this.StopMoving();
                                    break;
                                case CollisionDetector.Touching.right:
                                    this.ChangeDirection(touching);
                                    (entity as MarioEntity).currentPowerState.TakeDamage();

                                    break;
                                case CollisionDetector.Touching.left:
                                    this.ChangeDirection(touching);
                                    (entity as MarioEntity).currentPowerState.TakeDamage();

                                    break;
                            }
                            break;
                    }
                    break;
                case ItemEntity:
                    if (entity is FireballEntity)
                    {
                        SoundStorage.Instance.PlayStomp();
                        this.TakeDamage();
                    }
                    else
                    {
                        Enemy.Position = position;
                        if (touching == CollisionDetector.Touching.left)
                        {
                            this.ChangeDirection(touching);
                        }
                        else if (touching == CollisionDetector.Touching.right)
                        {
                            this.ChangeDirection(touching);
                        }
                    }
                    break;
                case BlockEntity:
                    Enemy.Position = position;
                    switch (touching)
                    {
                        case CollisionDetector.Touching.left:
                            this.ChangeDirection(touching);
                            break;
                        case CollisionDetector.Touching.right:
                            this.ChangeDirection(touching);
                            break;
                        case CollisionDetector.Touching.bottom:
                            Enemy.onGround = true;
                            break;
                    }
                    break;
                case EnemyEntity:
                    Enemy.Position = position;
                    switch (entity)
                    {
                         
                        case KoopaTroopaEntity:
                            if (touching == CollisionDetector.Touching.left)
                            {
                                this.ChangeDirection(touching);
                            }
                            else if (touching == CollisionDetector.Touching.right)
                            {
                                this.ChangeDirection(touching);
                            }
                            break;
                        case GoombaEntity:
                            if(this is KoopaTroopaNormalState)
                            {
                                if (touching == CollisionDetector.Touching.left)
                                {
                                    this.ChangeDirection(touching);
                                }
                                else if (touching == CollisionDetector.Touching.right)
                                {
                                    this.ChangeDirection(touching);
                                }
                            }
                            break;
                    }
                    break;
            }
        }
    }
}
