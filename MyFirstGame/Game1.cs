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

namespace Sprint0
{
    public class Game1 : Game
    {
        //new version ray
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private MarioEntity mario;

        private BrickBlockEntity brickBlock;
        private BlockEntity questionBlock;
        private BrickBlockEntity hiddenBrickBlock;

        //private Texture2D background;

        private IController keyboard;
        private IController gamepad;

        public static LevelData levelData { get; set; }


        private ItemFactory itemFactory = null;
        private MarioFactory marioFactory = null;
        private BlockFactory blockFactory = null;
        private EnemyFactory enemyFactory = null;

        private List<Entity> Entities = new List<Entity>();

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


            mario = new MarioEntity(this, new Vector2(150, 380));


            //-------------------------block initial----------------------
            questionBlock = new QuestionBlockEntity(this, new Vector2(100, 200), true);
            brickBlock = new BrickBlockEntity(this, new Vector2(200, 200), true);
            hiddenBrickBlock = new BrickBlockEntity(this, new Vector2(100, 300), false);



            //-------------------------keyboard control------------------
            
            keyboard = new KeyboardController();
            keyboard.Command((int)Keys.Q, new ExitCommand(this));
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

            keyboard.Command((int)Keys.C, new ShowBoundBox(levelBuilder.EntityStorage.EntityList));


            


            // -------------------------gamepad control----------------
            gamepad = new GamepadController(PlayerIndex.One);
            gamepad.Command((int)Buttons.Start, new ExitCommand(this));


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

            keyboard.Update();
            gamepad.Update();
            levelBuilder.EntityStorage.Update(gameTime);
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            //_spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);
            //_spriteBatch.DrawString(HUDFont, "Press Q(start) for quit\nPress W(A) E(B) R(X) T(Y) to show image", new Vector2(50, 0), fontColor);


            levelBuilder.EntityStorage.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void ExitCommnad()
        {
            Exit();
        }
    }
}