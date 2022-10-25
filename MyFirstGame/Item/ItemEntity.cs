using Microsoft.Win32.SafeHandles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Block.State;
using Sprint0.CollisionDetection;
using Sprint0.Interfaces;
using Sprint0.Item.State;
using Sprint0.Mario;
using Sprint0.Sprites;
using Sprint0.Sprites.factory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using static Sprint0.State.BlockEntity;

namespace Sprint0.Item
{
    public class ItemEntity : Entity, IMovableEntity
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
            EntityStorage.Instance.EntityList.Remove(this);
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
        //public void MovingTransition()
      //  {
           // switch (enum e)
           // {

           // }


         //  CurrentState?.MovingTransition();
      //  }
    }
}
