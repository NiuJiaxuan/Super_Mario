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
using static Sprint0.State.BlockEntity;
using Sprint0.Item.State;

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

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }


    }
}
