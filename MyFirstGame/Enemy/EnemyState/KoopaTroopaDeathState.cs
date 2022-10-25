using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemy.EnemyState
{
    public class KoopaTroopaDeathState : EnemyState
    {
        public KoopaTroopaDeathState(EnemyEntity enemy)
             : base(enemy)
        {

        }
        public override void NormalTransition()
        {
            CurrentState.Exit();
            CurrentState = new KoopaTroopaNormalState(Enemy);
            CurrentState.Enter(this);
        }
        public override void Enter(IEnemyState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
            Enemy.Sprite = Enemy.EnemyFactory.CreateEnemy(Enemy.game, Enemy.Position, 4);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
