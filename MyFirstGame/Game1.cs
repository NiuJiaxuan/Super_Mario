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

namespace Sprint0
{
    public class Game1 : Game
    {
        //new version ray
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        
        //private Texture2D background;

        private IController keyboard;
        private IController gamepad;

        private MarioEntity mario;

        private BrickBlockEntity brickBlock;
        private BlockEntity questionBlock;
        private BrickBlockEntity hiddenBrickBlock;


        private ItemFactory itemFactory = null;
        private MarioFactory marioFactory = null;
        private BlockFactory blockFactory = null;
        private EnemyFactory enemyFactory = null;

        private List<Entity> Entities = new List<Entity>();


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
            mario = new MarioEntity(this, new Vector2(150, 390));
            Entities.Add(mario);

            //-------------------------enemy initial----------------------
            Entities.Add(new GoombaEntity(this, new Vector2(500, 100)));
            Entities.Add(new KoopaTroopaEntity(this, new Vector2(600, 100)));

            //-------------------------block initial----------------------
            questionBlock = new QuestionBlockEntity(this, new Vector2(100, 200), mario);
            brickBlock = new BrickBlockEntity(this, new Vector2(200, 200), mario, true);
            hiddenBrickBlock = new BrickBlockEntity(this, new Vector2(100, 300), mario, false);
            Entities.Add(questionBlock);
            Entities.Add(brickBlock);
            Entities.Add(hiddenBrickBlock);

            //-------------------------floor initial----------------------
            for (int i = 0; i < 100; i++)
            {
                Entities.Add(new FloorBlockEntity(this, new Vector2(30 * i, 420), mario));
                Entities.Add(new FloorBlockEntity(this, new Vector2(30 * i, 450), mario));
                Entities.Add(new FloorBlockEntity(this, new Vector2(30 * i, 480), mario));
            }

            //-------------------------stair initial----------------------
            for (int i = 0; i < 4 ; i++)
            {
                for (int j =  4; j > i ; j--) {
                    Entities.Add(new StairBlockEntity(this, new Vector2(650 + j * 30, 390 - i * 30), mario));
                }
            }

            //-------------------------item initial----------------------
            Entities.Add(new StarEntity(this, new Vector2(100, 300)));
            Entities.Add(new FireFlowerEntity(this, new Vector2(200, 300)));
            Entities.Add(new CoinEntity(this, new Vector2(300, 300)));
            Entities.Add(new SuperMushroomEntity(this, new Vector2(400, 300)));
            Entities.Add(new OneUpMushroomEntity(this, new Vector2(500, 300)));

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
            //background = this.Content.Load<Texture2D>("sky");
  

            //--------------------------------load font---------------------------------------
            HUDFont = Content.Load<SpriteFont>("File");



        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            keyboard.Update();
            gamepad.Update();


            foreach (Entity entity in Entities)
            {
                entity.Update(gameTime, Entities);
            }
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            //_spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);
            _spriteBatch.DrawString(HUDFont, "Press Q(start) for quit\nPress W(A) E(B) R(X) T(Y) to show image", new Vector2(50, 0), fontColor);

            foreach (Entity entity in Entities)
            {
                entity.Draw(_spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void ExitCommnad()
        {
            Exit();
        }
    }
}