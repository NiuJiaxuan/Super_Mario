using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Sprites;
using Sprint0.Command;
using Sprint0.Controller;
using Sprint0.interfaces;
using Sprint0.Mario;
using Sprint0.Block;
using Sprint0.Items;
using System.Collections.Generic;

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

        private MarioAvatar mario;
        private Coin coin;
        private Star star;
        private FireFlower fireFlower;
        private SuperMushroom superMushroom;
        private OneUpMushroom oneUpMushroom;
        private QuestionBlock questionBlock;
        private UsedBlock usedBlock;
        private FloorBlock floorBlock;
        private BrickBlock brickBlock;
        private StairBlock stairBlock;
        private BrickBlock hiddenBrickBlock;
 
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
            mario = new MarioAvatar(this, new Vector2(100, 100));
            fireFlower = new FireFlower(this, new Vector2(150, 100));
            coin = new Coin(this, new Vector2(200, 100));
            superMushroom = new SuperMushroom(this, new Vector2(250, 100));
            oneUpMushroom = new OneUpMushroom(this, new Vector2(300, 100));
            star = new Star(this, new Vector2(350, 100));
            questionBlock = new QuestionBlock(this, new Vector2(100, 200));
            usedBlock = new UsedBlock(this, new Vector2(150, 200));
            floorBlock = new FloorBlock(this, new Vector2(200, 200));
            brickBlock = new BrickBlock(this, new Vector2(250, 200));
            stairBlock = new StairBlock(this, new Vector2(300, 200));
            hiddenBrickBlock = new BrickBlock(this, new Vector2(100, 300));


            hiddenBrickBlock.Hide();

            //-------------------------keyboard control------------------
            keyboard = new KeyboardController();
            keyboard.Command((int)Keys.Q, new ExitCommand(this));
            keyboard.Command((int)Keys.I, new ChangeToFireMario(mario.marioContext));
            keyboard.Command((int)Keys.U, new ChangeToSuperMario(mario.marioContext));
            keyboard.Command((int)Keys.Y, new ChangeToNormalMario(mario.marioContext));
            keyboard.Command((int)Keys.OemQuestion, new QuestionBlockBump(questionBlock));
            keyboard.Command((int)Keys.B, new BrickBlockBump(brickBlock));
            keyboard.Command((int)Keys.H, new BrickBlockChangeVisible(hiddenBrickBlock));

            // -------------------------gamepad control----------------
            gamepad = new GamepadController(PlayerIndex.One);
            gamepad.Command((int)Buttons.Start, new ExitCommand(this));


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //non ani texture load
            background = this.Content.Load<Texture2D>("background");
  

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
            brickBlock.isSuperMario = mario.marioContext.isSuperMario;
            fireFlower.Update(gameTime);
            coin.Update(gameTime);
            superMushroom.Update(gameTime);
            oneUpMushroom.Update(gameTime);
            star.Update(gameTime);
            questionBlock.Update(gameTime);
            usedBlock.Update(gameTime);
            floorBlock.Update(gameTime);
            brickBlock.Update(gameTime);
            stairBlock.Update(gameTime);
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
            

            mario.Draw(_spriteBatch);
            fireFlower.Draw(_spriteBatch);
            coin.Draw(_spriteBatch);
            superMushroom.Draw(_spriteBatch);
            oneUpMushroom.Draw(_spriteBatch);
            star.Draw(_spriteBatch);
            questionBlock.Draw(_spriteBatch);
            usedBlock.Draw(_spriteBatch); 
            brickBlock.Draw(_spriteBatch); 
            stairBlock.Draw(_spriteBatch);
            floorBlock.Draw(_spriteBatch);
            hiddenBrickBlock.Draw(_spriteBatch);


            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void ExitCommnad()
        {
            Exit();
        }
    }
}