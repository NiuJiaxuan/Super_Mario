using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Sprint0.CollisionDetection;
using Sprint0.Sprites;

namespace Sprint0.Enemy.EnemyState
{
    public class PiranhaState : IEnemyState
    {
        protected IEnemyState previousState;
        IEnemyState IEnemyState.PreviousState { get { return previousState; } }
        protected IEnemyState CurrentState { get { return Enemy.currentState; } set { Enemy.currentState = value; } }
        public bool isRemoved = false;

        public EnemyEntity Enemy;
        protected PiranhaState(EnemyEntity enemy)
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
        public virtual void NormalTransition(string dir) { }
        public virtual void ShellTransition() { }
        public virtual void ShellBump(string dir) { }

        public virtual void EmergeTransition() { }
    }
}
