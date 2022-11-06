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
using Sprint0.Item;

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

        }
        public override void CollisionResponse(Entity entity, Vector2 position, CollisionDetector.Touching touching)
        {
            //this.Position = position;
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
                                else if (touching == CollisionDetector.Touching.left)
                                {
                                    NormalTransition("right");
                                    mario.TakeDamage();
                                }
                                else if (touching == CollisionDetector.Touching.right)
                                {
                                    NormalTransition("left");
                                    mario.TakeDamage();
                                }
                            }
                            else if (EnemyType.Equals(eEnemyType.IdleDeadKoopaTroopa))
                            {
                                if (touching == CollisionDetector.Touching.left)
                                {
                                    dir = "right";
                                    ShellBump(dir);
                                    EnemyType = eEnemyType.MovingDeadKoopaTroopa;
                                }
                                else if (touching == CollisionDetector.Touching.right)
                                {
                                    dir = "left";
                                    ShellBump(dir);
                                    EnemyType = eEnemyType.MovingDeadKoopaTroopa;
                                }
                                else if (touching == CollisionDetector.Touching.top)
                                {
                                    //Kills the troopa
                                    //EntityStorage.Instance.movableRemove(this);
                                    //EntityStorage.Instance.ColliableEntites.Remove(this);
                                }
                            }
                            else if (EnemyType.Equals(eEnemyType.MovingDeadKoopaTroopa))
                            {
                                if (touching == CollisionDetector.Touching.top)
                                {
                                    ShellBump("top");
                                    EnemyType = eEnemyType.IdleDeadKoopaTroopa;
                                }
                                else if (touching == CollisionDetector.Touching.left)
                                {
                                    dir = "right";
                                    ShellBump(dir);
                                    mario.TakeDamage();
                                }
                                else if (touching == CollisionDetector.Touching.right)
                                {
                                    dir = "left";
                                    ShellBump(dir);
                                    mario.TakeDamage();
                                }
                            }
                            break;
                    }
                    break;
                case BlockEntity:
                    Debug.WriteLine("IS colliding");
                    if (EnemyType.Equals(eEnemyType.KoopaTroopa))
                    {
                        if (touching == CollisionDetector.Touching.left)
                        {
                            NormalTransition("right");
                        }
                        else if (touching == CollisionDetector.Touching.right)
                        {
                            NormalTransition("left");
                        }
                    }
                    else if (EnemyType.Equals(eEnemyType.MovingDeadKoopaTroopa))
                    {
                        if (touching == CollisionDetector.Touching.left)
                        {
                            //switch direction to the right
                            dir = "right";
                            ShellBump(dir);
                            //EnemyType = eEnemyType.MovingDeadKoopaTroopa;

                        }
                        else if (touching == CollisionDetector.Touching.right)
                        {
                            //switch direction to the left
                            dir = "left";
                            ShellBump(dir);
                            EnemyType = eEnemyType.MovingDeadKoopaTroopa;
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
                                    NormalTransition("right");
                                }
                                else if (touching == CollisionDetector.Touching.right)
                                {
                                    Debug.WriteLine("Right");
                                    //switch direction to the left
                                    dir = "left";
                                    NormalTransition("left");
                                }
                            }
                            break;
                        case eEnemyType.KoopaTroopa:
                            if (EnemyType.Equals(eEnemyType.MovingDeadKoopaTroopa))
                            {
                                if (touching == CollisionDetector.Touching.left)
                                {
                                    //switch direction to the right
                                    dir = "right";
                                    NormalTransition("right");
                                }
                                else if (touching == CollisionDetector.Touching.right)
                                {
                                    Debug.WriteLine("Right");
                                    //switch direction to the left
                                    dir = "left";
                                    NormalTransition("left");
                                }
                            }
                            break;
                    }
                    break;
                case FireballEntity:
                    SoundStorage.Instance.PlayStomp();
                    EntityStorage.Instance.movableRemove(this);
                    EntityStorage.Instance.ColliableEntites.Remove(this);
                    break;
                default:
                    if (EnemyType.Equals(eEnemyType.KoopaTroopa))
                    {
                        if (touching == CollisionDetector.Touching.left)
                        {
                            NormalTransition("right");
                        }
                        else if (touching == CollisionDetector.Touching.right)
                        {
                            NormalTransition("left");
                        }
                    }
                    else if (EnemyType.Equals(eEnemyType.MovingDeadKoopaTroopa))
                    {
                        if (touching == CollisionDetector.Touching.left)
                        {
                            //switch direction to the right
                            dir = "right";
                            ShellBump(dir);
                            //EnemyType = eEnemyType.MovingDeadKoopaTroopa;

                        }
                        else if (touching == CollisionDetector.Touching.right)
                        {
                            //switch direction to the left
                            dir = "left";
                            ShellBump(dir);
                            EnemyType = eEnemyType.MovingDeadKoopaTroopa;
                        }
                    }
                    break;
            }
        }
        public override void Update(GameTime gameTime, List<Entity> blockEntities)
        {
            if (Math.Abs(Position.X - EntityStorage.Instance.Mario.Position.X) < 350
                && currentState == null)
            {
                currentState = new KoopaTroopaNormalState(this, dir);
                currentState.Enter(null);
                EntityStorage.Instance.MovableEntities.Add(this);
            }
            else if (Math.Abs(Position.X - EntityStorage.Instance.Mario.Position.X) > 350)
            {
                EntityStorage.Instance.MovableEntities.Remove(this);
            }
            base.Update(gameTime, blockEntities);
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
        }
    }
}
