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
            currentState = new GoombaNormalState(this, "left");
            currentState.Enter(null);

        }

        public override void CollisionResponse(Entity entity, Vector2 position, CollisionDetector.Touching touching)
        {
            //this.Position = position;
            switch (entity)
            {
                case MarioEntity:
                   
                        if (touching == CollisionDetector.Touching.top)
                        {
                            Debug.WriteLine("TOP SIde");
                            KillTransition();
                            EnemyType = eEnemyType.DeadGooma;
                        EntityStorage.Instance.movableRemove(this);
                            //EntityStorage.Instance.EntityList.Remove(this);
                        }
                        else if (touching == CollisionDetector.Touching.left)
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
                case BlockEntity:
                    
                    if (touching == CollisionDetector.Touching.left)
                    {
                        NormalTransition("right");
                    }
                    if (touching == CollisionDetector.Touching.right)
                    {
                        NormalTransition("left");
                    }
                    if (touching == CollisionDetector.Touching.bottom)
                    {
                        onGround = true;
                        Position = position;
                    }
                    
                    break;
                case ItemEntity:
                    
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
