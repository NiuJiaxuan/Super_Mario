using Microsoft.Xna.Framework;
using Sprint0.Enemy.EnemyState;
using Sprint0.Mario;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Sprites.factory;
using Sprint0.Sprites;
using static Sprint0.Enemy.EnemyEntity;

namespace Sprint0.Enemy.KoopaTroopaStates
{
    class KoopaTroopaNormalState : KoopaTroopaState
    {
        string direction;
        public KoopaTroopaNormalState(EnemyEntity enemy, string dir)
            : base(enemy)
        {
            direction = dir;
        }

        public MarioEntity Mario { get; set; }

        public override void Enter(IEnemyState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
            Enemy.Sprite = Enemy.EnemyFactory.CreateEnemy(Enemy.game, Enemy.Position, (int)eEnemyType.KoopaTroopa);
            
        }

        public override void ShellTransition()
        {
            CurrentState.Exit();
            CurrentState = new KoopaTroopaShellState(Enemy);
            CurrentState.Enter(this);
        }

        public override void Update(GameTime gameTime)
        {
            if(Enemy.Orientation == SpriteEffects.None)
            {
                Enemy.Speed = new Vector2(-40, Enemy.Speed.Y);
            }
            else if(Enemy.Orientation == SpriteEffects.FlipHorizontally)
            {
                Enemy.Speed = new Vector2(40, Enemy.Speed.Y);
            }
        }
    }
}
