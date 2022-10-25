using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Sprites.factory;
using Sprint0.Mario;
using Sprint0.CollisionDetection;
using Sprint0.Enemy.EnemyState;

namespace Sprint0.Enemy
{
    public class KoopaTroopaEntity : EnemyEntity
    {
        //public virtual EnemyFactory KoopaTroopaFactory => game.KoopaTroopaFactory;

        public KoopaTroopaEntity(Game1 game, Vector2 position)
            : base(game, position)
        {
            Sprite = EnemyFactory.CreateEnemy(game, position, (int)eEnemyType.KoopaTroopa);
            EnemyType = eEnemyType.KoopaTroopa;
            currentState = new KoopaTroopaNormalState(this);
            currentState.Enter(null);
        }
        public override void CollisionResponse(Entity entity, Vector2 position, CollisionDetector.Touching touching)
        {
            switch (entity)
            {
                case MarioEntity:
                    MarioEntity mario = (MarioEntity)entity;
                    if (touching == CollisionDetector.Touching.top)
                    {
                        ShellTransition();
                    }

                    break;
            }
        }
        public override void Update(GameTime gameTime, List<Entity> blockEntities)
        {
            base.Update(gameTime, blockEntities);
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
        }
    }
}
