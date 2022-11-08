using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;
using Sprint0.Sprites.factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.ScoreSystem
{
    public class HUD
    {
        SpriteFont currentFont;
        long timeCounter;
        long timeLimit = 4000000000;
        long timeHurry = 1000000000;
        public long TimeDisplay { get; set; } = 4000000000;
        GameTime gameTime;
        public bool isPasued = false, gameOver = false;
        private static HUD instance;
        public static HUD Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HUD();
                }
                return instance;
            }
        }
        private HUD() { }

        public void SetUpFont(SpriteFont font)
        {
            currentFont = font;
        }
        public void SetUpGameTime (GameTime currentTime)
        {
            gameTime = currentTime;
        }
        public void ResetTime()
        {
            TimeDisplay = 4000000000;
            timeLimit = 4000000000;
            timeCounter = 0;
        }
        public void TimeConcurrent()
        {
            if (!isPasued||gameOver)
            {
                timeCounter += gameTime.ElapsedGameTime.Ticks;
                TimeDisplay = timeLimit - timeCounter;
                if (TimeDisplay <= timeHurry)
                {
                    SoundStorage.Instance.PlayTimeWarning();
                }
            }
        }
        public void Draw (SpriteBatch batch)
        {
            Vector2 scorePosition = new Vector2(50, 0);
            Vector2 coinPosition = new Vector2 (250, 0);
            Vector2 currentPlayer = new Vector2(400, 0);
            Vector2 lifePosition = new Vector2(500, 0);
            Vector2 currentTime = new Vector2(600, 0);
            batch.DrawString(currentFont, "Score: " + ScoreSystemManager.Instance.Score, scorePosition, Color.White);
            batch.DrawString(currentFont, "Coin X " + CoinSystem.Instance.CoinCount, coinPosition, Color.White);
            batch.DrawString(currentFont, "Mario X " + LifeSystem.Instance.LifeCount, lifePosition, Color.White);
            batch.DrawString(currentFont, "Time: " + TimeDisplay / 10000000, currentTime, Color.White);
        }
    }
}
