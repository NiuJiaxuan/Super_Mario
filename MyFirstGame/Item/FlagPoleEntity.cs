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
using Sprint0.ScoreSystem;
using Sprint0.Block.State.GameState;

namespace Sprint0.Item
{
    public class FlagPoleEntity : ItemEntity
    {
        FlagEntity flag;
        bool canfall = false;
        bool canGetSocre = true;
        public FlagPoleEntity(Game1 game, Vector2 position)
            : base(game, position)
        {
            ItemType = eItemType.FlagPole;
            Sprite = ItemFactory.CreateItem(game, position, (int)ItemType);
            flag = new FlagEntity(game, new Vector2(position.X - 20, position.Y - 120));
        }
        public override void CollisionResponse(Entity entity, Vector2 position, CollisionDetector.Touching touching)
        {
            switch (entity)
            {
                case MarioEntity:
                    canfall = true;
                    if (canGetSocre)
                    {
                        ScoreSystemManager.Instance.Flagpole((int)(Position.Y - position.Y));
                        SoundStorage.Instance.PlayWin();
                        canGetSocre = false;
                    }
                    
                    break;
            }
        }
        public override void Update(GameTime gameTime, List<Entity> entities)
        {
            if (flag.Position.Y < 420 && canfall)
            {
                flag.Position = new Vector2(flag.Position.X, flag.Position.Y + 1);
            }
            if (flag.Position.Y == 420)
            {
                WinningState.Instance.winning();
            }
            base.Update(gameTime, entities);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            flag.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }
    }
}
