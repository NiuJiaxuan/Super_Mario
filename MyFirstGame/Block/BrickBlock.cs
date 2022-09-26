using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Block
{
    public class BrickBlock
    {
        public Game1 game;
        public Vector2 position;

        private ISprite brickBlock;




        public BrickBlock(Game1 game, Vector2 position)
        {
            this.game = game;
            this.position = position;

            brickBlock = BrickBlockFactory.Instance.CreateBlock(game, position);

        }

        public void Bump()
        {
            brickBlock.IsBump();
        }

        public void ChangeVisble()
        {
            brickBlock.ChangeToVisible();
        }

        public void Hide()
        {
            brickBlock.HideSprite();
        }

        public void Update(GameTime gameTime)
        {

            brickBlock.Update(gameTime);

        }

        public void Draw(SpriteBatch batch)
        {
            brickBlock.Draw(batch);
        }
    }
}
