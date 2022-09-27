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
            this.currentSprite = NormalMarioFactory.Instance.CreateMario(mario.game, mario.position, SpriteEffects.None);
            this.mario = mario;
        }
        public void Update(GameTime gameTime)
        {
            currentSprite.Update(gameTime);
        }
        public void Draw(SpriteBatch batch)
        {
            currentSprite.Draw(batch);
        }


    }

    public class FireMario : IState
    {
        private ISprite currentSprite;
        private MarioContext marioContext;

        public FireMario(MarioContext mario)
        {
            this.currentSprite = FireMarioFactory.Instance.CreateMario(mario.game, mario.position, SpriteEffects.None);
            this.marioContext = mario;
        }

        public void Update(GameTime gameTime)
        {

            currentSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch batch)
        {
            currentSprite.Draw(batch);
        }

    }

    public class SuperMario : IState
    {
        private ISprite currentSprite;
        private MarioContext marioContext;

        public SuperMario(MarioContext mario)
        {
            this.currentSprite = SuperMarioFactory.Instance.CreateMario(mario.game, mario.position,SpriteEffects.None);
            this.marioContext = mario;
        }

        public void Update(GameTime gameTime)
        {

            currentSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch batch)
        {
            currentSprite.Draw(batch);
        }
    }


    public class DeadMario : IState
    {
        private ISprite currentSprite;
        private MarioContext marioContext;

        public DeadMario(MarioContext mario)
        {
            this.currentSprite = DeadMarioFactory.Instance.DeadMario(mario.game, mario.position);
            this.marioContext = mario;
        }

        public void Update(GameTime gameTime)
        {

            currentSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch batch)
        {
            currentSprite.Draw(batch);
        }
    }
}
