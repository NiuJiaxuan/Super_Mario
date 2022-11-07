using Microsoft.Xna.Framework;
using Sprint0.Mario;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemy.EnemyState
{
    class GoombaNormalState : GoombaState
    {
        string direction;
        public GoombaNormalState(EnemyEntity enemy, string dir)
            : base(enemy)
        {
            Enemy.Speed = new Vector2(-40, 0);
            direction = dir;
        }

        public MarioEntity Mario { get; set; }

        public override void Enter(IEnemyState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
            if (direction == "left")
            {
                Enemy.Speed = new Vector2(-40, 0);
                Enemy.Position = new Vector2(Enemy.Position.X - 5, Enemy.Position.Y);
            }
            else if (direction == "right")
            {
                Debug.WriteLine("SHIFT");
                Enemy.Speed = new Vector2(40, 0);
                Enemy.Position = new Vector2(Enemy.Position.X + 5, Enemy.Position.Y);
            }
        }
        public override void NormalTransition(string dir)
        {
            CurrentState.Exit();
            CurrentState = new GoombaNormalState(Enemy, dir);
            CurrentState.Enter(this);
        }

        public override void KillTransition()
        {
            CurrentState.Exit();
            CurrentState = new GoombaDeathState(Enemy);
            CurrentState.Enter(this);
        }
      
    }
}
