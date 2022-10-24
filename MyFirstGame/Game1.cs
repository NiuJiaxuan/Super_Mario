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

namespace Sprint0
{
    public class Game1 : Game
    {
        //new version ray
        public GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        private Texture2D background;

        private IController keyboard;
        private IController gamepad;
        Vector2 parallax = new Vector2(1f);

        Camera camera;
        public static LevelData levelData { get; set; }


        private ItemFactory itemFactory = null;
        private MarioFactory marioFactory = null;
        private BlockFactory blockFactory = null;
        private EnemyFactory enemyFactory = null;

        private LevelBuilder levelBuilder;


        public MarioFactory MarioFactory
        {
            get { return marioFactory ?? MarioFactory.Instance; }
            protected set { marioFactory = value; }
        }
        public ItemFactory ItemFactory
        {
            get { return itemFactory ?? ItemFactory.Instance; }
            protected set { itemFactory = value; }
        }
        public BlockFactory BlockFactory
        {
            get { return blockFactory ?? BlockFactory.Instance; }
            protected set { blockFactory = value; }
        }

        public EnemyFactory EnemyFactory
        {
            get { return enemyFactory ?? EnemyFactory.Instance; }
            protected set { enemyFactory = value; }
        }



        public Color fontColor { get; set; } = Color.White;
        //private SpriteFont HUDFont;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            levelBuilder = new LevelBuilder();
            levelBuilder.LodeLevel(this);
            levelData = levelBuilder.LevelData;
            camera = new Camera(GraphicsDevice.Viewport);
            camera.Limits= new Rectangle(0,0,6000,450);

            background = Content.Load<Texture2D>("background");



            //-------------------------keyboard control------------------
            
            keyboard = new KeyboardController();
            keyboard.Command((int)Keys.Q, new ExitCommand(this));
            keyboard.Command((int)Keys.R, new ResetCommand(this));
            keyboard.Command((int)Keys.I, new ChangeToFireMario(levelBuilder.EntityStorage.Mario));
            keyboard.Command((int)Keys.U, new ChangeToSuperMario(levelBuilder.EntityStorage.Mario));
            keyboard.Command((int)Keys.Y, new ChangeToNormalMario(levelBuilder.EntityStorage.Mario));
            keyboard.Command((int)Keys.O, new MarioTakeDamege(levelBuilder.EntityStorage.Mario));

            keyboard.Command((int)Keys.W, new MarioJump(levelBuilder.EntityStorage.Mario));
            keyboard.Command((int)Keys.Up, new MarioJump(levelBuilder.EntityStorage.Mario));

            keyboard.Command((int)Keys.S, new MarioCrouch(levelBuilder.EntityStorage.Mario));
            keyboard.Command((int)Keys.Down, new MarioCrouch(levelBuilder.EntityStorage.Mario));

            keyboard.Command((int)Keys.A, new MarioWalkLeft(levelBuilder.EntityStorage.Mario));
            keyboard.Command((int)Keys.Left, new MarioWalkLeft(levelBuilder.EntityStorage.Mario));

            keyboard.Command((int)Keys.D, new MarioWalkRight(levelBuilder.EntityStorage.Mario));
            keyboard.Command((int)Keys.Right, new MarioWalkRight(levelBuilder.EntityStorage.Mario));

            keyboard.Command((int)Keys.C, new ShowBoundBox(EntityStorage.Instance.EntityList));

            


            // -------------------------gamepad control----------------
            gamepad = new GamepadController(PlayerIndex.One);
            gamepad.Command((int)Buttons.Start, new ExitCommand(this));

            gamepad.Command((int)Buttons.DPadUp, new MarioJump(levelBuilder.EntityStorage.Mario));
            gamepad.Command((int)Buttons.DPadDown, new MarioCrouch(levelBuilder.EntityStorage.Mario));
            gamepad.Command((int)Buttons.DPadLeft, new MarioWalkLeft(levelBuilder.EntityStorage.Mario));
            gamepad.Command((int)Buttons.DPadRight, new MarioWalkRight(levelBuilder.EntityStorage.Mario));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //--------------------------------load font---------------------------------------
           // HUDFont = Content.Load<SpriteFont>("File");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            camera.LookAt(levelBuilder.EntityStorage.Mario.Position);
            keyboard.Update();
            gamepad.Update();
            levelBuilder.EntityStorage.Update(gameTime, _graphics);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            //_spriteBatch.Begin();

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camera.GetViewMatrix(parallax));

            _spriteBatch.Draw(background, new Rectangle(0, 0, 1600, 480), Color.White);
            //_spriteBatch.DrawString(HUDFont, "Press Q(start) for quit\nPress W(A) E(B) R(X) T(Y) to show image", new Vector2(50, 0), fontColor);


            levelBuilder.EntityStorage.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }


        public void ResetCommand()
        {
            Initialize();
            
        }
        public void ExitCommnad()
        {
            Exit();
        }
    }
}