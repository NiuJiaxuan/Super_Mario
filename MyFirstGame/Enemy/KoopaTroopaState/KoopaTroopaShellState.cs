using Microsoft.Xna.Framework;
using Sprint0.Enemy.EnemyState;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemy.KoopaTroopaStates
{
    public class KoopaTroopaShellState : KoopaTroopaState
    {
        private static readonly TimeSpan intervalBetweenAlive = TimeSpan.FromMilliseconds(4000);
        private int lastTimeAlive;
        public KoopaTroopaShellState(EnemyEntity enemy)
             : base(enemy)
        {
        }

        public override void Enter(IEnemyState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
            Enemy.Sprite = Enemy.EnemyFactory.CreateEnemy(Enemy.game, Enemy.Position, 4);
        }

        public override void NormalTransition(string dir)
        {
            CurrentState.Exit();
            CurrentState = new KoopaTroopaNormalState(Enemy,dir);
            CurrentState.Enter(this);
        }
        public override void ShellMovingTransition(string dir)
        {
            CurrentState.Exit();
            CurrentState = new KoopaTroopaMovingShellState(Enemy, dir);
            CurrentState.Enter(previousState);
        }
        public override void Update(GameTime gameTime)
        {
            Enemy.Speed = new Vector2(0, 0);
            lastTimeAlive += gameTime.ElapsedGameTime.Milliseconds;
            if (lastTimeAlive >= 3000)
                revive();
                
        }

    }
}
