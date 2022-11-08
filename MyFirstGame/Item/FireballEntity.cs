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
using System.Net.Http.Headers;
using Sprint0.State;
using Sprint0.Block;

namespace Sprint0.Item
{
    public class FireballEntity : ItemEntity
    {
        public List<Entity> FireballPool;
        public FireballEntity(Game1 game, Vector2 position, List<Entity>fireballPool)
            : base(game, position)
        {
            FireballPool = fireballPool;
            ItemType = eItemType.Fireball;
            if(EntityStorage.Instance.Mario.Orientation == SpriteEffects.None)
            {
                Sprite = ItemFactory.CreateItem(game, new Vector2(position.X + EntityStorage.Instance.Mario.Sprite.FrameSize.X , position.Y -20), (int)ItemType);
            }
            else
            {
                Sprite = ItemFactory.CreateItem(game, new Vector2(position.X - 12, position.Y - 20), (int)ItemType);

            }
            CurrentState = new FireballMovingState(this);
            CurrentState.Enter(null);
        }
        public override void CollisionResponse(Entity entity, Vector2 position, CollisionDetector.Touching touching)
        {
            switch (entity)
            {
                case BlockEntity:
                    Position = position;
                    if (touching == CollisionDetector.Touching.bottom || entity is FloorBlockEntity)
                    {
                        this.Speed = new Vector2(Speed.X, -200);
                    }
                    else
                    {
                        EntityStorage.Instance.completeRemove(this);
                        FireballPool.Add(this);
                    }
                    break;
                default:
                    EntityStorage.Instance.completeRemove(this);
                    FireballPool.Add(this);
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

        public void BouncingTransition()
        {
            CurrentState?.BouncingTransition();
        }


    }
}
