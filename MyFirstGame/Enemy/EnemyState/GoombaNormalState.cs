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
    class GoombaNormalState : EnemyState
    {
        string direction;
        public GoombaNormalState(EnemyEntity enemy)
            : base(enemy)
        {

        }

        public MarioEntity Mario { get; set; }

        public override void Enter(IEnemyState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
            if (direction == "left")
            {
                Enemy.Speed = new Vector2(-40, 0);
            }
            else if (direction == "right")
            {
                Enemy.Speed = new Vector2(40, 0);
            }
        }

        public override void KillTransition()
        {
            CurrentState.Exit();
            CurrentState = new GoombaDeathState(Enemy);
            CurrentState.Enter(this);
        }
      
    }
}
