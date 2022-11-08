using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemy.EnemyState
{
    public class PiranhaEmergeState : PiranhaState
    {
        Vector2 Origin;

        public PiranhaEmergeState(EnemyEntity enemy)
              : base(enemy)
        {
        }

        public override void Enter(IEnemyState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
            Origin = Enemy.Position;

            Enemy.Speed = new Vector2(0, -30);
        }

        public override void Exit()
        {
            Enemy.Speed = new Vector2(0, 0);
            //EntityStorage.Instance.completeRemove(Enemy);
        }

        public override void NormalTransition(string dir)
        {
            CurrentState.Exit();
            CurrentState = new PiranhaNormalState(Enemy);
            CurrentState.Enter(this);
        }

        public override void Update(GameTime gameTime)
        {
            if (Math.Abs(Enemy.Position.Y - Origin.Y) >= 45)
                Exit();
        }

    }
}
