﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Block.State;
using Sprint0.Interfaces;
using Sprint0.Mario;
using Sprint0.Sprites;
using Sprint0.State;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Block
{
    public class FloorBlockEntity : BlockEntity, IStaticEntity
    {
        public FloorBlockEntity(Game1 game, Vector2 position)
            : base(game, position)
        {
            Sprite = BlockFactory.CreateBlock(game, position, (int)eBlockType.FloorBlock);
            BlockType = eBlockType.FloorBlock;
            CurrentState = new FloorBlockNormalState(this);
            CurrentState.Enter(null);

        }
        public override void Update(GameTime gameTime, List<Entity> blockEntities)
        {
            base.Update(gameTime, blockEntities);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
