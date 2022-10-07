using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Block.State;
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
        public bool isVisible = true;

        public BrickBlockEntity(Game1 game, Vector2 position)
            : base(game, position)
        {
            Sprite = BlockFactory.CreateBlock(game,position, (int)eBlockType.BrickBlock);
            BlockType = eBlockType.BrickBlock;
            CurrentState = new BrickBlockNormalState(this);
            CurrentState.Enter(null);

        }
        public void hideBrickBlock()
        {
            isVisible = false;
        }

        public void changeToVisible()
        {
            isVisible = true;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
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
