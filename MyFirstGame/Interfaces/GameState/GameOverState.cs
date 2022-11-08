using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Command;
using Sprint0.Interfaces;
using Sprint0.ScoreSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Block.State.GameState
{
    public class GameOverState : IGameState
    {
        public SpriteFont Font;
        public Texture2D background;
        public bool candraw = false;
        private static GameOverState instance;

        public static GameOverState Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameOverState();
                }
                return instance;
            }
        }

        public void loadGameOverBackground(ContentManager content, SpriteFont font)
        {
            background = content.Load<Texture2D>("gameover");
            Font = font;
        }

        public void gameOver()
        {
            HUD.Instance.gameOver = !HUD.Instance.gameOver;
            EntityStorage.Instance.gameOver = true;
            candraw = !candraw;

        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if (candraw)
            {
                spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);

                spriteBatch.DrawString(Font, "Press R to replay " , new Vector2(350, 300), Color.White);
                spriteBatch.DrawString(Font, "Press Q to quit " , new Vector2(350, 350), Color.White);
            }
            spriteBatch.End();
        }
    }
}
