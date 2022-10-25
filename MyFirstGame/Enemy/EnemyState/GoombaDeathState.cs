using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemy.EnemyState
{
    public class GoombaDeathState : EnemyState
    {
        private static readonly TimeSpan intervalBetweenAlive = TimeSpan.FromMilliseconds(4000);
        private TimeSpan lastTimeAlive;
        EnemyEntity goomba;
        public GoombaDeathState(EnemyEntity enemy)
              : base(enemy)
        {
            goomba = enemy;
        }
        public override void NormalTransition(string dir)
        {
            CurrentState.Exit();
            CurrentState = new GoombaNormalState(Enemy, dir);
            CurrentState.Enter(this);
        }
        public override void Enter(IEnemyState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
            Enemy.Sprite = Enemy.EnemyFactory.CreateEnemy(Enemy.game, Enemy.Position, 3);
        }
        //public override void Update(GameTime gameTime)
        //{
        //    Enemy.Speed = new Vector2(0, 0);
        //    if (lastTimeAlive + intervalBetweenAlive < gameTime.TotalGameTime)
        //    {
        //        Death();
        //        lastTimeAlive = gameTime.TotalGameTime;
        //    }
        //}
    }
}
