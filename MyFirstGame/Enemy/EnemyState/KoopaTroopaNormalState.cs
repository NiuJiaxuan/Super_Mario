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
