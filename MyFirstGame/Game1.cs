using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Sprites;
using Sprint0.Command;
using Sprint0.Controller;
using Sprint0.interfaces;

namespace Sprint0
{
    public class Game1 : Game
    {
        //new version ray
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private NmNaSprite nmna;
        private MNaSprite mna;
        private NmASprite nma;
        private MASprite ma;
        
        private Texture2D background;
        private Texture2D kirby;

        private IController keyboard;
        private IController gamepad;
 
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
            kirby = this.Content.Load<Texture2D>("3-2-kirby-picture");

            //----------------------non animated-----------------------

            //non moving non animated sprite create 
            nmna = new NmNaSprite(kirby, new Vector2(200, 300));
            //non mv non ani display command
            keyboard.Command((int)Keys.W, new ShowNmNaCommand(this.nmna));
            gamepad.Command((int)Buttons.A, new ShowNmNaCommand(nmna));

            // mv non ani sprite create
            mna = new MNaSprite(kirby, new Vector2(450, 240));
            // mv non ani display command
            keyboard.Command((int)Keys.E, new ShowMNaCommand(this.mna));
            gamepad.Command((int)Buttons.X, new ShowMNaCommand(mna));

            //----------------------animated texture load-------------------------------

            //load animated texture
            var skyman = Content.Load<Texture2D>("skymanRow");

            //--------------------------------animated-------------------------------------

            //non mv ani sprite create
            nma = new NmASprite(skyman, 1, 8, new Vector2(100,100));
            //non mv ani sprite display command connected
            keyboard.Command((int)Keys.R, new ShowNmACommand(nma));
            gamepad.Command((int)Buttons.B, new ShowNmACommand(nma));

            //mv ani sprite create
            ma = new MASprite(skyman, 1, 8, new Vector2(100,200));
            keyboard.Command((int)Keys.T, new ShowMACommand(ma));
            gamepad.Command((int)Buttons.Y, new ShowMACommand(ma));

            //load font
            HUDFont = Content.Load<SpriteFont>("File");


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            keyboard.Update();
            gamepad.Update();

            nmna.Update();
            mna.Update();
            nma.Update();
            ma.Update();


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

            nmna.Draw(_spriteBatch);
            mna.Draw(_spriteBatch);
            nma.Draw(_spriteBatch);
            ma.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void ExitCommnad()
        {
            Exit();
        }
    }
}