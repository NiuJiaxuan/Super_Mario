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

        private ISprite brickBlock;
        private ISprite brickBlockPiece1;
        private ISprite brickBlockPiece2;
        private ISprite brickBlockPiece3;
        private ISprite brickBlockPiece4;




        public BrickBlock(Game1 game, Vector2 position)
        {
            this.game = game;
            this.position = position;
            
            brickBlock = BrickBlockFactory.Instance.CreateBlock(game, position);
            brickBlockPiece1 = BrickBlockPieceFactory.Instance.CreateBlock(game, position);
            brickBlockPiece2 = BrickBlockPieceFactory.Instance.CreateBlock(game, new Vector2(position.X + 16 , position.Y));
            brickBlockPiece3 = BrickBlockPieceFactory.Instance.CreateBlock(game, new Vector2(position.X , position.Y + 16));
            brickBlockPiece4 = BrickBlockPieceFactory.Instance.CreateBlock(game, new Vector2(position.X + 16 , position.Y + 16));
            brickBlockPiece1.NegativeHorizonVelocity();
            brickBlockPiece3.NegativeHorizonVelocity();
        }

        public void Bump()
        {
            brickBlock.IsBump();
        }

        public void ChangeVisble()
        {
            brickBlock.ChangeToVisible();
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
            brickBlock.HideSprite();
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

        public void Update(GameTime gameTime)
        {

            brickBlock.Update(gameTime);
            brickBlockPiece1.Update(gameTime);
            brickBlockPiece2.Update(gameTime);
            brickBlockPiece3.Update(gameTime);
            brickBlockPiece4.Update(gameTime);
        }

        public void Draw(SpriteBatch batch)
        {
            brickBlock.Draw(batch);
            brickBlockPiece1.Draw(batch);
            brickBlockPiece2.Draw(batch);
            brickBlockPiece3.Draw(batch);
            brickBlockPiece4.Draw(batch);
        }


    }
}
