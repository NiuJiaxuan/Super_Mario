using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Interfaces;
using System.Diagnostics;
using Sprint0.Sprites;
using Sprint0.CollisionDetection;

namespace Sprint0.Enemy.EnemyState
{
    public class KoopaTroopaMovingShellState : EnemyState
    {
        Vector2 Origin;
        string direction;
        public KoopaTroopaMovingShellState(EnemyEntity enemy, string dir) 
            : base(enemy)
        {
            direction = dir;
        }

        public override void Enter(IEnemyState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
            Origin = Enemy.Position;

            if (direction == "left")
            {
                Enemy.Speed = new Vector2(-40, 0);
            }
            else if (direction == "right")
            {
                Enemy.Speed = new Vector2(40, 0);
            }
            else if (direction == "top")
            {
                Enemy.Speed = new Vector2(0, 0);
            }
        }

        public override void Exit()
        {
            Enemy.Speed = new Vector2(0, 0);
        }

        public override void NormalTransition()
        {
            CurrentState.Exit();
            CurrentState = new KoopaTroopaNormalState(Enemy);
            CurrentState.Enter(this);
        }
        public override void ShellBump(string dir)
        {
            CurrentState.Exit();
            CurrentState = new KoopaTroopaMovingShellState(Enemy, dir);
            CurrentState.Enter(this);
        }


        //public override void Update(GameTime gameTime)
        //{
        //    if (Math.Abs(Enemy.Position.X - Origin.X) > 10)
        //        Enemy.Speed = new Vector2(Enemy.Speed.X * -1, 0);
        //}
    }
    }
