using Microsoft.Xna.Framework;
using Sprint0.CollisionDetection;
using Sprint0.Enemy;
using Sprint0.Item;
using Sprint0.Mario.MarioMotionState;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
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

            this.FireTransion();
        }
        public void Normal()
        {

            this.NormalTransion();
        }
        public void Super()
        {

            this?.SuperTransion();
        }
        public void TakeDamage()
        {
            switch (this)
            {
                case NormalState:
                    this?.DeadTransion();
                    break;
                case SuperState:
                    this?.NormalTransion();
                    break;
                case FireState:
                    this?.SuperTransion();
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
                                TakeDamage();
                            }
                            break;
                        case KoopaTroopaEntity:

                            break;
                    }
                    break;
                case ItemEntity:
                    switch (entity)
                    {
                        case FireFlowerEntity:
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

                            break;
                        case CoinEntity:

                            break;
                        case SuperMushroomEntity:
                            if (this.GetType() == typeof(NormalState))
                                Super();
                            break;
                        case StarEntity:
                            //turn to star mario 
                            break;
                    }
                    break;
            }
        }
    }
}
