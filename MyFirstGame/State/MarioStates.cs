using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.interfaces;
using Sprint0.Mario;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.State
{
    public class NormalMario : IState
    {
        private ISprite currentSprite;
        private MarioContext mario;

        public NormalMario(MarioContext mario)
        {
            this.currentSprite = NormalMarioFactory.Instance.IdleMario(mario.game, mario.position);
            this.mario = mario;
        }



        public void Draw(SpriteBatch batch)
        {
            currentSprite.Draw(batch);
        }

        public void Update(GameTime gameTime)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.F))
            mario.setState(new FireMario(mario));

            currentSprite.Update(gameTime);
        }
    }

    public class FireMario : IState
    {
        private ISprite currentSprite;
        private MarioContext marioContext;

        public FireMario(MarioContext mario)
        {
            this.currentSprite = FireMarioFactory.Instance.IdleMario(mario.game, mario.position);
            this.marioContext = mario;
        }



        public void Draw(SpriteBatch batch)
        {
            currentSprite.Draw(batch);
        }

        public void Update(GameTime gameTime)
        {

            currentSprite.Update(gameTime);
        }
    }

}
