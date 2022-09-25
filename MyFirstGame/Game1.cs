using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Sprites;
using Sprint0.Command;
using Sprint0.Controller;
using Sprint0.interfaces;
using Sprint0.Mario;

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

            //-------------------------keyboard control------------------
            keyboard = new KeyboardController();
            keyboard.Command((int)Keys.Q, new ExitCommand(this));

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


            mario = new MarioAvatar(this, new Vector2(100, 100));

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            keyboard.Update();
            gamepad.Update();

            mario.Update(gameTime);

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

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void ExitCommnad()
        {
            Exit();
        }
    }
}