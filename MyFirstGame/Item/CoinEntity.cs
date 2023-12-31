﻿using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Block.State;
using Sprint0.Item.State;
using Sprint0.CollisionDetection;
using Sprint0.State;

namespace Sprint0.Item
{
    public class CoinEntity : ItemEntity
    {
        public CoinEntity(Game1 game, Vector2 position)
            : base(game, position)
        {
            ItemType = eItemType.Coin;
            Sprite = ItemFactory.CreateItem(game, position, (int)ItemType);
            CurrentState = new CoinNormalState(this);
            CurrentState.Enter(null);
        }
        public override void CollisionResponse(Entity entity, Vector2 position, CollisionDetector.Touching touching)
        {
            SoundStorage.Instance.PlayCoin();
            EntityStorage.Instance.completeRemove(this);
            base.CollisionResponse(entity, position, touching);
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
