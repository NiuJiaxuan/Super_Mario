﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.CollisionDetection;
using Sprint0.Sprites.factory;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.State;
using Sprint0.Mario;

namespace Sprint0.Item
{
    public class FlagPoleEntity : ItemEntity
    {
        public FlagPoleEntity(Game1 game, Vector2 position)
            : base(game, position)
        {
            ItemType = eItemType.FlagPole;
            Sprite = ItemFactory.CreateItem(game, position, (int)ItemType);
        }
        public override void CollisionResponse(Entity entity, Vector2 position, CollisionDetector.Touching touching)
        {
            switch (entity)
            {
                case MarioEntity:
                    
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
