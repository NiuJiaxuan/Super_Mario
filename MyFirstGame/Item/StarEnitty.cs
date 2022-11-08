using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Sprites;
using Sprint0.Item.State;
using Sprint0.CollisionDetection;
using Sprint0.Mario;
using Sprint0.Block;
using Sprint0.Enemy;

namespace Sprint0.Item
{
    public class StarEntity : ItemEntity
    {
        public StarEntity(Game1 game, Vector2 position)
            : base(game, position)
        {
            ItemType = eItemType.Star;
            Sprite = ItemFactory.CreateItem(game, position, (int)ItemType);
            CurrentState = new StarNormalState(this);
            CurrentState.Enter(null);
        }

        public override void CollisionResponse(Entity entity, Vector2 position, CollisionDetector.Touching touching)
        {
            switch (entity)
            {
                case MarioEntity:
                    EntityStorage.Instance.completeRemove(this);
                    break;
                case BlockEntity:
                    Position = position;
                    switch (touching)
                    {
                        case CollisionDetector.Touching.bottom:
                            this.Speed = new Vector2(Speed.X, -200);
                            break;
                        case CollisionDetector.Touching.top:

                            break;
                        case CollisionDetector.Touching.left:
                            this.Speed = new Vector2(-Speed.X, Speed.Y);
                            break;
                        case CollisionDetector.Touching.right:
                            this.Speed = new Vector2(-Speed.X, Speed.Y);
                            break;
                    }
                    break;
                case EnemyEntity:
                    currentColliding = entity;
                    EntityStorage.Instance.ColliableEntites.Remove(this);
                    break;
                case ItemEntity:
                    currentColliding = entity;
                    EntityStorage.Instance.ColliableEntites.Remove(this);
                    break;
            }
        }

        public override void Update(GameTime gameTime, List<Entity> entities)
        {
            base.Update(gameTime, entities);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }


    }
}
