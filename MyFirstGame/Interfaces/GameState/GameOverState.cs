using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
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
        public Texture2D background;
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
        
        public GameOverState()
        {
            
        }
        public void loadGameOverBackground(ContentManager content)
        {
            background = content.Load<Texture2D>("gameover");
        }

        public void gameOver()
        {
            HUD.Instance.gameOver = !HUD.Instance.gameOver;
        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Rectangle(0,0,800,480), Color.White);
        }
    }
}
