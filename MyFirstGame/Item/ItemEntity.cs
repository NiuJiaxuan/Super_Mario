using Microsoft.Win32.SafeHandles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Block;
using Sprint0.Block.State;
using Sprint0.CollisionDetection;
using Sprint0.Enemy;
using Sprint0.Interfaces;
using Sprint0.Item.State;
using Sprint0.Mario;
using Sprint0.Sprites;
using Sprint0.Sprites.factory;
using Sprint0.State;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sprint0.Item
{
    public class ItemEntity : Entity, IGravityEntity//, IMovableEntity
    {

        public virtual ItemFactory ItemFactory => game.ItemFactory;
        public enum eItemType
        {
            Coin = 0,
            SuperMushroom = 1,
            FireFlower = 2,
            OneUpMushroom = 3,
            Star = 4,
            Pipe = 5,
            None = 6,
            Castle = 7,
            Fireball = 8,
            FlagPole = 9,
            Flag =10, 
        }
        public IItemState CurrentState { get; set; }
        public eItemType ItemType { get; set; }

        public ItemEntity(Game1 game, Vector2 position)
            : base(game, position)
        {
        }

        public override void CollisionResponse(Entity entity, Vector2 position, CollisionDetector.Touching touching)
        {
            //Debug.WriteLine("item response");
            switch (entity)
            {
                case MarioEntity:
                    EntityStorage.Instance.EntityList.Remove(this);
                    EntityStorage.Instance.ColliableEntites.Remove(this);
                    break;
                case BlockEntity:
                    Position = position;
                    if(touching == CollisionDetector.Touching.bottom)
                        onGround = true;
                    break;
                //case EnemyEntity:
                    //Position = position;
                    //break;
                    // item response
                case ItemEntity:
                    Position = position;
                    break;

            }
        }

        public override void Update(GameTime gameTime, List<Entity> entities)
        {            
            base.Update(gameTime, entities);

            CurrentState?.Update(gameTime); 
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsVisible) {  
                base.Draw(spriteBatch);
            }
        }

        public void changeToVisible()
        {
            IsVisible = true;
        }

        public void BumpTransition()
        {
            CurrentState?.BumpTransition();
        }
    }
}
