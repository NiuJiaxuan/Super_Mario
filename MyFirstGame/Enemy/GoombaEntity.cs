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
                    MarioEntity mario = (MarioEntity)entity;
                    switch (touching)
                    {
                        case CollisionDetector.Touching.bottom:
                            onGround = true;
                            break;
                        case CollisionDetector.Touching.top:
                            Debug.WriteLine("TOP SIde");
                            KillTransition();
                            EnemyType = eEnemyType.DeadGooma;
                            EntityStorage.Instance.ColliableEntites.Remove(this);
                            break;
                        case CollisionDetector.Touching.left:
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

                    KillTransition();
                    EnemyType = eEnemyType.DeadGooma;
                    EntityStorage.Instance.movableRemove(this);
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
                            this.Speed = Vector2.Zero;
                            break;
                        case KoopaTroopaEntity:
                            EntityStorage.Instance.movableRemove(this);
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
            }
            base.Update(gameTime, blockEntities);

        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
        }

    }
}
