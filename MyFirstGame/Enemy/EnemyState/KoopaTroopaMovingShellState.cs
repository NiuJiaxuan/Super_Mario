using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Sprint0.Sprites;
using Sprint0.CollisionDetection;

namespace Sprint0.Enemy.EnemyState
{
    public class KoopaTroopaMovingShellState : KoopaTroopaState
    {
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

            //Debug.WriteLine("ENTER DEBUG :" + direction);
            if (direction == "left")
            {
                Enemy.Speed = new Vector2(-40, 0);
                Enemy.Position = new Vector2(Enemy.Position.X - 5, Enemy.Position.Y);
            }
            else if (direction == "right")
            {
                Enemy.Speed = new Vector2(40, 0);
                Enemy.Position = new Vector2(Enemy.Position.X + 5, Enemy.Position.Y);
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

        public override void NormalTransition(string dir)
        {
            CurrentState.Exit();
            CurrentState = new KoopaTroopaNormalState(Enemy, dir);
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
        //    //if (Math.Abs(Enemy.Position.X - Origin.X) > 10)
        //    //    Enemy.Speed = new Vector2(Enemy.Speed.X * -1, 0);
        //    base.Update(gameTime);
        //}
    }
}
