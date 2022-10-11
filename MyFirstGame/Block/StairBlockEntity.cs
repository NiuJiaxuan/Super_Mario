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
    public class StairBlockEntity : BlockEntity
    {
        public StairBlockEntity(Game1 game, Vector2 position)
            : base(game, position)
        {
            Sprite = BlockFactory.CreateBlock(game, position, (int)eBlockType.StairBlock);
            BlockType = eBlockType.StairBlock;
            CurrentState = new StairBlockNormalState(this);
            CurrentState.Enter(null);

        }
        public override void Update(GameTime gameTime, List<Entity> entities)
        {
            base.Update(gameTime,entities);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
