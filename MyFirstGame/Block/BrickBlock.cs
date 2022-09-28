using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Mario;

namespace Sprint0.Block
{
    public class BrickBlock
    {
        public Game1 game;
        public Vector2 position;
        public bool isSuperMario;
        public bool isContain = true;

        private ISprite currentBlock;
        private ISprite brickBlock;
        private ISprite hiddenItem;
        private ISprite usedBlock;
        private ISprite brickBlockPiece1;
        private ISprite brickBlockPiece2;
        private ISprite brickBlockPiece3;
        private ISprite brickBlockPiece4;




        public BrickBlock(Game1 game, Vector2 position)
        {
            this.game = game;
            this.position = position;
            
            brickBlock = BrickBlockFactory.Instance.CreateBlock(game, position);
            hiddenItem = SuperMushroomFactory.Instance.Create(game, position);
            usedBlock = UsedBlockFactory.Instance.CreateBlock(game, position);
            hiddenItem.HideSprite();
            brickBlockPiece1 = BrickBlockPieceFactory.Instance.CreateBlock(game, position);
            brickBlockPiece2 = BrickBlockPieceFactory.Instance.CreateBlock(game, new Vector2(position.X + 24 , position.Y));
            brickBlockPiece3 = BrickBlockPieceFactory.Instance.CreateBlock(game, new Vector2(position.X , position.Y + 24));
            brickBlockPiece4 = BrickBlockPieceFactory.Instance.CreateBlock(game, new Vector2(position.X + 24 , position.Y + 24));
            brickBlockPiece1.NegativeHorizonVelocity();
            brickBlockPiece3.NegativeHorizonVelocity();
            currentBlock = brickBlock;
        }

        public void Bump()
        {
            if (isContain)
            {
                hiddenItem.ChangeToVisible();
            }
            else
            {
                currentBlock = usedBlock;
            }
            currentBlock.IsBump();
        }

        public void ChangeVisble()
        {
            currentBlock.ChangeToVisible();
        }

        public void ChangeToSuperMario()
        {
            
            brickBlockPiece1.IsSuperMario();
            brickBlockPiece2.IsSuperMario();
            brickBlockPiece3.IsSuperMario();
            brickBlockPiece4.IsSuperMario();
        }

        public void Hide()
        {
            currentBlock.HideSprite();
        }

        public void Explode()
        {
            if (isSuperMario)
            {
                Hide();
                ChangeToSuperMario();
                brickBlockPiece1.ChangeToVisible();
                brickBlockPiece2.ChangeToVisible();
                brickBlockPiece3.ChangeToVisible();
                brickBlockPiece4.ChangeToVisible();
            }
        }

        public void ContainItem()
        {
            isContain = true;
        }

        public void Update(GameTime gameTime)
        {

            currentBlock.Update(gameTime);
            hiddenItem.Update(gameTime);
            brickBlockPiece1.Update(gameTime);
            brickBlockPiece2.Update(gameTime);
            brickBlockPiece3.Update(gameTime);
            brickBlockPiece4.Update(gameTime);
        }

        public void Draw(SpriteBatch batch)
        {
            currentBlock.Draw(batch);
            hiddenItem.Draw(batch);
            brickBlockPiece1.Draw(batch);
            brickBlockPiece2.Draw(batch);
            brickBlockPiece3.Draw(batch);
            brickBlockPiece4.Draw(batch);
        }
       


    }
}
