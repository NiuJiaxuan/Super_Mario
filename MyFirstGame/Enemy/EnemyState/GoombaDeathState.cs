using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemy.EnemyState
{
    public class GoombaDeathState : EnemyState
    {
        public GoombaDeathState(EnemyEntity enemy)
              : base(enemy)
        {

        }
        public override void Enter()
        {
            CurrentState = this;
            Enemy.Sprite = Enemy.EnemyFactory.CreateEnemy(Enemy.game, Enemy.Position, 3);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
