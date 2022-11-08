using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Command;
using Sprint0.Controller;
using Sprint0.interfaces;
using Sprint0.Mario;
using Sprint0.Block.State;
using Sprint0.State;
using Sprint0.Block;
using Sprint0.Enemy;
using Sprint0.Sprites.factory;
using Sprint0.Sprites;
using System.Collections.Generic;
using Sprint0.Item;
using System.Diagnostics;
using Sprint0.level;
using System.Reflection.PortableExecutable;
using Sprint0.CollisionDetection;
using Sprint0.Interfaces;
using System;
using Microsoft.Xna.Framework.Audio;
using Sprint0.ScoreSystem;
using Sprint0.Block.State.GameState;
using Sprint0.Timers;

namespace Sprint0
{
    public class Game1 : Game
    {
        //new version ray
        public GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        SpriteFont font;
        bool isTimeUp = false;

        private Texture2D background;
        private Texture2D bush;
        private Texture2D cloud;

        private IController gamepad;

        Camera camera;
        public static LevelData levelData { get; set; }


        private ItemFactory itemFactory = null;
        private MarioFactory marioFactory = null;
        private BlockFactory blockFactory = null;
        private EnemyFactory enemyFactory = null;

        private LevelBuilder levelBuilder;

        private CollisionDetector cd = CollisionDetector.Instance;



        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            base.Initialize();
            EntityStorage.Instance.Game = this;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            SoundStorage.Instance.LoadSounds(Content);
            levelBuilder = new LevelBuilder();
            levelBuilder.LodeLevel(this);
            levelData = levelBuilder.LevelData;
            camera = new Camera(GraphicsDevice.Viewport);
            camera.Limits = new Rectangle(0, 0, 6300, 480);
            background = Content.Load<Texture2D>("background");
            cloud = Content.Load<Texture2D>("cloud");
            bush= Content.Load<Texture2D>("bush");
            EntityStorage.Instance.initialCommand(this);
            EntityStorage.Instance.initialCheckPoints();
            SoundStorage.Instance.PlayBGM();


            font = Content.Load<SpriteFont>("file");
            HUD.Instance.SetUpFont(font);
            GameOverState.Instance.loadGameOverBackground(Content, font);
            WinningState.Instance.loadWinningBackground(Content, font);

            // -------------------------gamepad control----------------
            gamepad = new GamepadController(PlayerIndex.One);
            gamepad.Command((int)Buttons.Start, new ExitCommand(this));

            gamepad.Command((int)Buttons.DPadUp, new MarioJump(levelBuilder.EntityStorage.Mario));
            gamepad.Command((int)Buttons.DPadDown, new MarioCrouch(levelBuilder.EntityStorage.Mario));
            gamepad.Command((int)Buttons.DPadLeft, new MarioWalkLeft(levelBuilder.EntityStorage.Mario));
            gamepad.Command((int)Buttons.DPadRight, new MarioWalkRight(levelBuilder.EntityStorage.Mario));

        }

        protected override void Update(GameTime gameTime)
        {

            camera.LookAt(levelBuilder.EntityStorage.Mario.Position);
            gamepad.Update();
            levelBuilder.EntityStorage.Update(gameTime);
            TimerManager.Instance.Update(gameTime);
            HUD.Instance.SetUpGameTime(gameTime);
            HUD.Instance.TimeConcurrent();

            if (HUD.Instance.TimeDisplay < 0 && !isTimeUp)
            {
                SoundStorage.Instance.StopBGM();
                if (!LifeSystem.Instance.isNoLife)
                EntityStorage.Instance.Mario.Die();
                isTimeUp = true;
            }
            if (isTimeUp && HUD.Instance.TimeDisplay < -30000000)
            {
                ResetCommand();
                isTimeUp = false;
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap, null, null);
            _spriteBatch.Draw(background, new Rectangle((int)(-camera.Position.X*0.5f), (int)(camera.Position.Y*0.5f), 3500, 430), Color.White);
            _spriteBatch.Draw(cloud, new Vector2(0, 50), new Rectangle((int)(camera.Position.X * 0.7f), (int)(camera.Position.Y * 0.5f), 1300, 120), Color.White);
            _spriteBatch.Draw(bush, new Vector2(0,330),new Rectangle((int)(camera.Position.X * 0.6f), (int)(camera.Position.Y * 0.5f), 1300, 100), Color.White);
            _spriteBatch.End();

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camera.GetViewMatrix(new Vector2(1f)));
            //_spriteBatch.DrawString(HUDFont, "Press Q(start) for quit\nPress W(A) E(B) R(X) T(Y) to show image", new Vector2(50, 0), fontColor);
            levelBuilder.EntityStorage.Draw(_spriteBatch);
            _spriteBatch.End();

            GameOverState.Instance.Draw(_spriteBatch);
            WinningState.Instance.Draw(_spriteBatch);

            _spriteBatch.Begin();
            HUD.Instance.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }


        public void ResetCommand()
        {
            levelBuilder.EntityStorage.clear();
            levelBuilder = new LevelBuilder();
            levelBuilder.LodeLevel(this);
            levelData = levelBuilder.LevelData;
            EntityStorage.Instance.initialCommand(this);
            HUD.Instance.ResetTime();
            ScoreSystemManager.Instance.ResetScore();
            CoinSystem.Instance.resetCoin();
            SoundStorage.Instance.PlayBGM();
            LifeSystem.Instance.resetLife();

            GameOverState.Instance.candraw = false;
            EntityStorage.Instance.gameOver = false;
            HUD.Instance.gameOver = false;

            WinningState.Instance.candraw = false;
            
        }

        public void ExitCommnad()
        {
            Exit();
        }
    }
}