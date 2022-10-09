using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Block.State;
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
    public class BrickBlockEntity : BlockEntity
    {


        public BrickBlockEntity(Game1 game, Vector2 position, MarioEntity mario)
            : base(game, position,mario)
        {
            Sprite = BlockFactory.CreateBlock(game,position, (int)eBlockType.BrickBlock);
            BlockType = eBlockType.BrickBlock;
            CurrentState = new BrickBlockNormalState(this);
            CurrentState.Enter(null);

        }

        public override void Update(GameTime gameTime, List<Entity> entities)
        {
            base.Update(gameTime,entities);

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible)
            {
                base.Draw(spriteBatch);
            }
        }
    }
}
