using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Sprint0.Sprites;
using Sprint0.CollisionDetection;
using Sprint0.Enemy.EnemyState;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Enemy.KoopaTroopaStates
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
            //if (direction == "left")
            //{
            //    Enemy.Speed = new Vector2(-40, 0);
            //    Enemy.Position = new Vector2(Enemy.Position.X - 5, Enemy.Position.Y);
            //}
            //else if (direction == "right")
            //{
            //    Enemy.Speed = new Vector2(40, 0);
            //    Enemy.Position = new Vector2(Enemy.Position.X + 5, Enemy.Position.Y);
            //}
            //else if (direction == "top")
            //{
            //    Enemy.Speed = new Vector2(0, 0);
            //}
        }

        public override void Exit()
        {
            Enemy.Speed = new Vector2(0, 0);
        }

        public override void ShellTransition()
        {
            CurrentState.Exit();
            CurrentState = new KoopaTroopaShellState(Enemy);
            CurrentState.Enter(previousState);
        }


        public override void Update(GameTime gameTime)
        {
            if (Enemy.Orientation == SpriteEffects.None)
            {
                Enemy.Speed = new Vector2(-40, Enemy.Speed.Y);
            }
            else if (Enemy.Orientation == SpriteEffects.FlipHorizontally)
            {
                Enemy.Speed = new Vector2(40, Enemy.Speed.Y);
            }
            //if (Math.Abs(Enemy.Position.X - Origin.X) > 10)
            //    Enemy.Speed = new Vector2(Enemy.Speed.X * -1, 0);
        }
    }
}
