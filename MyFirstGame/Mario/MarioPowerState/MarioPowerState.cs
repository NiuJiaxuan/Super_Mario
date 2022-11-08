using Microsoft.Xna.Framework;
using Sprint0.CollisionDetection;
using Sprint0.Enemy;
using Sprint0.Item;
using Sprint0.Mario.MarioMotionState;
using Sprint0.ScoreSystem;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Mario.MarioPowerState
{
    public abstract class MarioPowerState : IMarioPowerState
    {
        protected IMarioPowerState previousState;

        public MarioEntity Mario { get; set; }
        protected IMarioPowerState CurrentState { get { return Mario.currentPowerState; }set { Mario.currentPowerState = value; } }

        IMarioPowerState IMarioPowerState.PreviousState { get { return previousState;} }

        protected IMarioMotionState CurrentMotionState { get { return Mario.currentMotionState; } }

        protected MarioPowerState(MarioEntity mario)
        {
            Mario = mario;

        }

        public virtual void Enter(IMarioPowerState powerState)
        {
            CurrentState = this;
            this.previousState = powerState;
        }

        public virtual void Exit() { }
        public virtual void NormalTransion() { }
        public virtual void FireTransion() { }
        public virtual void SuperTransion() { }
        public virtual void DeadTransion() { }
        public virtual void Update(GameTime gameTime) { }

        public void Fire()
        {
            SoundStorage.Instance.PlayPowerUp();
            FireTransion();
        }
        public void Normal()
        {

            NormalTransion();
        }
        public void Super()
        {
            SoundStorage.Instance.PlayPowerUp();
            SuperTransion();
        }
        public void TakeDamage()
        {
            //Debug.WriteLine("take damage");
            switch (this)
            {
                case NormalState:
                    DeadTransion();
                    break;
                case SuperState:
                    NormalTransion();
                    break;
                case FireState:
                    SuperTransion();
                    break;
            }
        }

        public void CollisionResponse(Entity entity, Vector2 position, CollisionDetector.Touching touching)
        {
            switch (entity)
            {
                case EnemyEntity:
                    switch (entity)
                    {
                        case GoombaEntity:
                            if (touching == CollisionDetector.Touching.right || touching == CollisionDetector.Touching.left || touching == CollisionDetector.Touching.top)
                            {
                                if(this.GetType() != typeof(DeadState))
                                TakeDamage();
                            }
                            break;
                        case KoopaTroopaEntity:

                            break;
                        case PiranhaEntity:
                            TakeDamage();
                            break;
                    }
                    break;
                case ItemEntity:
                    switch (entity)
                    {
                        case FireFlowerEntity:
                            ScoreSystemManager.Instance.FireFlower();
                            if (this.GetType() == typeof(SuperState))
                            {
                                Fire();
                            }
                            if (this.GetType() == typeof(NormalState))
                            {
                                Super();
                            }
                            break;
                        case OneUpMushroomEntity:
                            LifeSystem.Instance.GainOneLife();
                            break;
                        case CoinEntity:
                            ScoreSystemManager.Instance.Coin();
                            break;
                        case SuperMushroomEntity:
                            if (this.GetType() == typeof(NormalState))
                                Super();
                            break;
                        case StarEntity:
                            ScoreSystemManager.Instance.Star();
                            break;
                    }
                    break;
            }
        }
    }
}
