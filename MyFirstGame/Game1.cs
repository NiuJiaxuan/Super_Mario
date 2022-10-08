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

namespace Sprint0
{
    public class Game1 : Game
    {
        //new version ray
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        
        private Texture2D background;

        private IController keyboard;
        private IController gamepad;

        private MarioEntity mario;
        private BlockEntity brickBlock;
        private BlockEntity questionBlock;
        private BlockEntity hiddenBrickBlock;
        private BlockEntity floorBlock;
        private BlockEntity stairBlock;
        private GoombaEntity goomba;
        private KoopaTroopaEntity koopaTroopa;

        private ItemFactory itemFactory = null;
        private MarioFactory marioFactory = null;
        private BlockFactory blockFactory = null;
        private EnemyFactory goombaFactory = null;
        private EnemyFactory koopaTroopaFactory = null;

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
        public EnemyFactory GoombaFactory
        {
            get { return koopaTroopaFactory ?? EnemyFactory.Instance; }
            protected set { koopaTroopaFactory = value; }
        }

        public EnemyFactory KoopaTroopaFactory
        {
            get { return goombaFactory ?? EnemyFactory.Instance; }
            protected set { goombaFactory = value; }
        }


        public Color fontColor { get; set; } = Color.White;
        private SpriteFont HUDFont;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //-------------------------mario initial----------------------
            mario = new MarioEntity(this, new Vector2(100, 100));

            //-------------------------enemy initial----------------------
            goomba = new GoombaEntity(this, new Vector2(500, 100));
            koopaTroopa = new KoopaTroopaEntity(this, new Vector2(600, 100));

            //-------------------------block initial----------------------
            questionBlock = new QuestionBlockEntity(this, new Vector2(100, 200),mario);
            brickBlock = new BrickBlockEntity(this, new Vector2(200, 200),mario);
            floorBlock = new FloorBlockEntity(this, new Vector2(300, 200),mario);
            stairBlock = new StairBlockEntity(this, new Vector2(400, 200),mario);
            hiddenBrickBlock = new BrickBlockEntity(this, new Vector2(100, 300),mario);
            hiddenBrickBlock.hideBrickBlock();


            //-------------------------keyboard control------------------
            keyboard = new KeyboardController();
            keyboard.Command((int)Keys.Q, new ExitCommand(this));
            keyboard.Command((int)Keys.I, new ChangeToFireMario(mario));
            keyboard.Command((int)Keys.U, new ChangeToSuperMario(mario));
            keyboard.Command((int)Keys.Y, new ChangeToNormalMario(mario));
            keyboard.Command((int)Keys.O, new MarioTakeDamege(mario));

            keyboard.Command((int)Keys.W, new MarioJump(mario));
            keyboard.Command((int)Keys.Up, new MarioJump(mario));

            keyboard.Command((int)Keys.S, new MarioCrouch(mario));
            keyboard.Command((int)Keys.Down, new MarioCrouch(mario));

            keyboard.Command((int)Keys.A, new MarioWalkLeft(mario));
            keyboard.Command((int)Keys.Left, new MarioWalkLeft(mario));

            keyboard.Command((int)Keys.D, new MarioWalkRight(mario));
            keyboard.Command((int)Keys.Right, new MarioWalkRight(mario));

            keyboard.Command((int)Keys.B, new BlockBumpOrBreak(brickBlock));
            keyboard.Command((int)Keys.OemQuestion, new BlockBump(questionBlock));
            keyboard.Command((int)Keys.H, new ChangeToVisible(hiddenBrickBlock));



            // -------------------------gamepad control----------------
            gamepad = new GamepadController(PlayerIndex.One);
            gamepad.Command((int)Buttons.Start, new ExitCommand(this));


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //non ani texture load
            background = this.Content.Load<Texture2D>("sky");
  

            //--------------------------------load font---------------------------------------
            HUDFont = Content.Load<SpriteFont>("File");



        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            keyboard.Update();
            gamepad.Update();

            mario.Update(gameTime);       
            goomba.Update(gameTime);
            koopaTroopa.Update(gameTime);
            brickBlock.Update(gameTime);
            questionBlock.Update(gameTime);
            stairBlock.Update(gameTime);
            floorBlock.Update(gameTime);
            hiddenBrickBlock.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);
            _spriteBatch.DrawString(HUDFont, "Press Q(start) for quit\nPress W(A) E(B) R(X) T(Y) to show image", new Vector2(50, 0), fontColor);
            //_spriteBatch.Draw(earth, new Vector2(400,240),Color.White);
            //_spriteBatch.Draw(shuttle, new Vector2(450, 240), Color.White);

            mario.Draw(_spriteBatch);
            goomba.Draw(_spriteBatch);
            koopaTroopa.Draw(_spriteBatch);
            brickBlock.Draw(_spriteBatch);
            questionBlock.Draw(_spriteBatch);
            hiddenBrickBlock.Draw(_spriteBatch);    
            stairBlock.Draw(_spriteBatch);
            floorBlock.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void ExitCommnad()
        {
            Exit();
        }
    }
}