using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Mario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemy.EnemyState
{
    class KoopaTroopaNormalState : EnemyState
    {
        public KoopaTroopaNormalState(EnemyEntity enemy)
            : base(enemy)
        {
            Enemy.Speed = new Vector2(-40, 0);
        }

        public MarioEntity Mario { get; set; }

        public override void Enter(IEnemyState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;

        }

        public override void ShellTransition()
        {
            CurrentState.Exit();
            CurrentState = new KoopaTroopaDeathState(Enemy);
            CurrentState.Enter(this);
        }

    }
}
