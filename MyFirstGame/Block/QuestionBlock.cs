using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Block
{
    public class QuestionBlock
    {
        public Game1 game;
        public Vector2 position;

        private ISprite questionBlock;
        private ISprite usedBlock;
        private ISprite currentBlock;
        private ISprite hiddenItem;



        public QuestionBlock(Game1 game, Vector2 position)
        {
            this.game = game;
            this.position = position;
            questionBlock = QuestionBlockFactory.Instance.CreateBlock(game, position); 
            usedBlock = UsedBlockFactory.Instance.CreateBlock(game, position);
            hiddenItem = CoinFactory.Instance.Create(game, position);
            hiddenItem.HideSprite();
            currentBlock = questionBlock;

        }

        public void ChangeToUsedBlock ()
        {
            currentBlock = usedBlock;
            currentBlock.IsBump();
        }

        public void ContainItem()
        {
            hiddenItem.ChangeToVisible();
            hiddenItem.IsAppear();
        }

        public void Update(GameTime gameTime)
        {

            currentBlock.Update(gameTime);
            hiddenItem.Update(gameTime);

        }

        public void Draw(SpriteBatch batch)
        {
            hiddenItem.Draw(batch);
            currentBlock.Draw(batch);
            
        }

    }
}
