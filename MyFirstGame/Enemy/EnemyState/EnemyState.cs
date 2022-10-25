using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;

namespace Sprint0.Enemy.EnemyState
{
    public class EnemyState : IEnemyState
    {
        protected IEnemyState previousState;
        IEnemyState IEnemyState.PreviousState { get { return previousState; } }
        protected IEnemyState CurrentState { get { return Enemy.currentState; } set { Enemy.currentState = value; } }

        public EnemyEntity Enemy;
        protected EnemyState(EnemyEntity enemy)
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
        public virtual void KillTransition() { }
        public virtual void NormalTransition() { }
        public virtual void ShellTransition() { }


    }
}
