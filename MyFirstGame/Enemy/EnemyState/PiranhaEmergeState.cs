using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemy.EnemyState
{
    public class PiranhaEmergeState : PiranhaState
    {
        Vector2 Origin;
        string direction;


        public PiranhaEmergeState(EnemyEntity enemy, string dir)
              : base(enemy)
        {
            direction = dir;
        }

        public override void Enter(IEnemyState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
            Origin = Enemy.Position;
            if (direction.Equals("up"))
            {
                Enemy.Speed = new Vector2(0, -30);
            }
            else if (direction.Equals("down"))
            {
                Debug.WriteLine("DOWN SPEED!!!");
                Enemy.Speed = new Vector2(0, 30);
            }
        }

        public override void Exit()
        {
            Enemy.Speed = new Vector2(0, 0);
            //EntityStorage.Instance.completeRemove(Enemy);
        }

        public override void EmergeTransition(string dir)
        {
            CurrentState.Exit();
            CurrentState = new PiranhaEmergeState(Enemy, dir);
            CurrentState.Enter(this);
        }

        public override void NormalTransition(string dir)
        {
            CurrentState.Exit();
            CurrentState = new PiranhaNormalState(Enemy);
            CurrentState.Enter(this);
        }

        public override void Update(GameTime gameTime)
        {
            if (direction.Equals("up"))
            {
                if (Math.Abs(Enemy.Position.Y - Origin.Y) >= 46)
                    Exit();
            }
            else if (direction.Equals("down"))
            {
                //origin = 100
                //enemy = 100 -> 146
                if (Math.Abs(Enemy.Position.Y - Origin.Y) >= 50)
                {
                    EntityStorage.Instance.ColliableEntites.Remove(Enemy);
                    EntityStorage.Instance.completeRemove(Enemy);
                    Exit();
                }
            }
        }

    }
}
