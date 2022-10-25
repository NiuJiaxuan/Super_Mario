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
using System.Diagnostics;
using Sprint0.Mario.MarioPowerState;
using Sprint0.State;

namespace Sprint0.Enemy
{
    public class KoopaTroopaEntity : EnemyEntity
    {
        //public virtual EnemyFactory KoopaTroopaFactory => game.KoopaTroopaFactory;
        string dir;
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
                    switch (mario.currentPowerState)
                    {
                        case DeadState:
                                break;
                        default:
                            if (EnemyType.Equals(eEnemyType.KoopaTroopa))
                            {
                                if (touching == CollisionDetector.Touching.top)
                                {
                                    ShellTransition();
                                    EnemyType = eEnemyType.IdleDeadKoopaTroopa;
                                }
                                else
                                {
                                    mario.TakeDamage();
                                }
                            }
                            else if (EnemyType.Equals(eEnemyType.IdleDeadKoopaTroopa))
                            {
                                Debug.WriteLine("Bump:" + touching.ToString());
                                //ERROR: CollisionDetector is not detecting the right collision!
                                if (touching == CollisionDetector.Touching.left)
                                {
                                    dir = "right";
                                    ShellBump(dir);
                                    EnemyType = eEnemyType.MovingDeadKoopaTroopa;
                                }
                                else if ( touching == CollisionDetector.Touching.right)
                                {
                                    dir = "left";
                                    ShellBump(dir);
                                    EnemyType = eEnemyType.MovingDeadKoopaTroopa;
                                }
                                else if (touching == CollisionDetector.Touching.top)
                                {
                                    //Kills the troopa
                                }
                            }
                            else if (EnemyType.Equals(eEnemyType.MovingDeadKoopaTroopa))
                            {
                                if (touching == CollisionDetector.Touching.top)
                                {
                                    dir = "top";
                                    ShellBump(dir);
                                    EnemyType = eEnemyType.IdleDeadKoopaTroopa;
                                }
                            }
                            break;
                    }
                    break;
                case BlockEntity:
                    if (EnemyType.Equals(eEnemyType.KoopaTroopa))
                    {
                        if (touching == CollisionDetector.Touching.left)
                        {
                            //switch direction to the right
                            dir = "right";
                        }
                        else if (touching == CollisionDetector.Touching.right)
                        {
                            //switch direction to the left
                            dir = "left";
                        }
                    }
                    else if (EnemyType.Equals(eEnemyType.MovingDeadKoopaTroopa))
                    {
                        if(touching != CollisionDetector.Touching.left)
                        {
                            //switch direction to the right
                            dir = "right";
                            ShellBump(dir);
                        }
                        else if (touching == CollisionDetector.Touching.right)
                        {
                            //switch direction to the left
                            dir = "left";
                            ShellBump(dir);
                        }
                    }
                    break;
                case EnemyEntity:
                    EnemyEntity enemy = (EnemyEntity)entity;
                    switch (enemy.EnemyType)
                    {
                        case eEnemyType.Goomba:
                            if (EnemyType.Equals(eEnemyType.MovingDeadKoopaTroopa))
                            {
                                if (touching == CollisionDetector.Touching.left)
                                {
                                    //switch direction to the right
                                    dir = "right";
                                    Debug.WriteLine("GO RIGHT");
                                    ShellBump(dir);
                                }
                                else if (touching == CollisionDetector.Touching.right)
                                {
                                    //switch direction to the left
                                    dir = "left"; 
                                    ShellBump(dir);
                                }
                            }
                            break;
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
