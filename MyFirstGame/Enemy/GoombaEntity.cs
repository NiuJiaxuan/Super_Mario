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
using Sprint0.State;
using Sprint0.Item;
using Sprint0.Interfaces;
using Sprint0.Block;

namespace Sprint0.Enemy
{
    public class GoombaEntity : EnemyEntity //, IMovableEntity
    {
        public GoombaEntity(Game1 game, Vector2 position)
            : base(game, position) 
        {
            //currentState = new IdleState(this);
            Sprite = EnemyFactory.CreateEnemy(game, position,(int)eEnemyType.Goomba);
            EnemyType = eEnemyType.Goomba;
        }

        public override void CollisionResponse(Entity entity, Vector2 position, CollisionDetector.Touching touching)
        {
            //this.Position = position;
            switch (entity)
            {
                case MarioEntity:

                    switch (touching)
                    {
                        case CollisionDetector.Touching.bottom:
                            onGround = true;
                            break;
                        case CollisionDetector.Touching.top:

                            if(EntityStorage.Instance.EntityList.Contains(this)
                                && EnemyType == eEnemyType.DeadGooma)
                            {
                                EntityStorage.Instance.completeRemove(this);
                            }

                            Debug.WriteLine("TOP SIde");
                            KillTransition();
                            EnemyType = eEnemyType.DeadGooma;
                            
                            break;
                        case CollisionDetector.Touching.left:
                            if(Speed.X <0)
                            NormalTransition("right");
                            break;
                        case CollisionDetector.Touching.right:
                            NormalTransition("left");
                            break;
                    }
                    break;
                case BlockEntity:
                    Debug.WriteLine("goomba touch block from " + touching);
                    switch(touching)
                    {
                        case CollisionDetector.Touching.bottom:
                            onGround = true;
                            Position = position;
                            break;
                        case CollisionDetector.Touching.left:
                            NormalTransition("right");
                            break;
                        case CollisionDetector.Touching.right:
                            NormalTransition("left");
                            break;
                    }
                    
                    break;
                case FireballEntity:

                    SoundStorage.Instance.PlayStomp();
                    KillTransition();
                    EnemyType = eEnemyType.DeadGooma;
                    EntityStorage.Instance.completeRemove(this);
                    break;

                default:
                    if (touching == CollisionDetector.Touching.left)
                    {
                        //currentState = new GoombaNormalState(this, "right");
                        NormalTransition("right");
                    }
                    else if (touching == CollisionDetector.Touching.right)
                    {
                        //currentState = new GoombaNormalState(this, "right");
                        NormalTransition("left");
                    }
                    break;
                case EnemyEntity:
                    switch (entity)
                    {
                        case GoombaEntity:
                            if (touching == CollisionDetector.Touching.left)
                            {
                                //currentState = new GoombaNormalState(this, "right");
                                NormalTransition("right");
                            }
                            else if (touching == CollisionDetector.Touching.right)
                            {
                                //currentState = new GoombaNormalState(this, "right");
                                NormalTransition("left");
                            }
                            break;
                        case KoopaTroopaEntity:
                            if (touching == CollisionDetector.Touching.left)
                            {
                                //currentState = new GoombaNormalState(this, "right");
                                NormalTransition("right");
                            }
                            else if (touching == CollisionDetector.Touching.right)
                            {
                                //currentState = new GoombaNormalState(this, "right");
                                NormalTransition("left");
                            }
                            break;
                    }
                    break;
            }
        }

        public override void Update(GameTime gameTime, List<Entity> blockEntities)
        {
            if (Math.Abs(Position.X - EntityStorage.Instance.Mario.Position.X) < 350 
                && currentState == null)
            {
                currentState = new GoombaNormalState(this, "left");
                currentState.Enter(null);
                EntityStorage.Instance.MovableEntities.Add(this);
            }
            else if(Position.X - EntityStorage.Instance.Mario.Position.X < -350)
            {
                EntityStorage.Instance.completeRemove(this);
            }
            else if(Position.Y > 480)
            {
                EntityStorage.Instance.completeRemove(this);
            }
            base.Update(gameTime, blockEntities);

        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
        }

    }
}
