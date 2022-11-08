using Microsoft.Xna.Framework;
using Sprint0.Sprites.factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemy.EnemyState
{
    public class PiranhaNormalState : PiranhaState
    {
        public PiranhaNormalState(EnemyEntity item)
           : base(item)
        {
        }

        public override void Enter(IEnemyState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;

            Vector2 Origin = Vector2.Zero;
            if (Enemy.Sprite != null)
            {
                Origin = Enemy.Position;
            }

            Enemy.Sprite = Enemy.EnemyFactory.CreateEnemy(Enemy.game, Enemy.Position, (int)EnemySpriteFactory.eEnemeyType.Piranha);
            Enemy.EnemyType = EnemyEntity.eEnemyType.Piranha;
            Enemy.Position = Origin;
        }

        public override void EmergeTransition()
        {
            CurrentState.Exit();
            CurrentState = new PiranhaEmergeState(Enemy);
            CurrentState.Enter(this);
        }
    }
}
