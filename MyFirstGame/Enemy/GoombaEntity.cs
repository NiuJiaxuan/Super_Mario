using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Enemy.EnemyState;
using Sprint0.Mario;
using Sprint0.Sprites;
using Sprint0.Sprites.factory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.CollisionDetection;

namespace Sprint0.Enemy
{
    public class GoombaEntity : EnemyEntity
    {
        public GoombaEntity(Game1 game, Vector2 position)
            : base(game, position) 
        {
            //currentState = new IdleState(this);
            Sprite = EnemyFactory.CreateEnemy(game, position,(int)eEnemyType.Goomba);
            EnemyType = eEnemyType.Goomba;
            currentState = new GoombaNormalState(this);
            currentState.Enter(null);

        }

        public override void CollisionResponse(Entity entity, Vector2 position, CollisionDetector.Touching touching)
        {
            switch (entity)
            {
                case MarioEntity:
                    MarioEntity mario = (MarioEntity)entity;
                    if (EnemyType.Equals(eEnemyType.Goomba))
                    {
                        if (touching == CollisionDetector.Touching.top)
                        {
                            KillTransition();
                            EnemyType = eEnemyType.DeadGooma;
                        }
                        else
                        {
                            mario.TakeDamage();
                        }
                    }
                break;
                case EnemyEntity:
                    EnemyEntity enemy = (EnemyEntity)entity;
                    switch(enemy.currentState)
                    {
                        case KoopaTroopaMovingShellState:
                            if (touching == CollisionDetector.Touching.right) 
                            {
                                Debug.WriteLine("Kill");
                                Position = position;
                                //KillTransition();
                                //EnemyType = eEnemyType.DeadGooma;
                            }
                            break;
                    }
                    if(touching == CollisionDetector.Touching.top)
                    {                        
                        if (currentState is GoombaDeathState)
                            EntityStorage.Instance.EntityList.Remove(this);
                        Debug.WriteLine("TOP");
                        KillTransition();

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
