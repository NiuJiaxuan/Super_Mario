using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Sprites;
using Sprint0.interfaces;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites
{
    //Abstract sprite factory class
    // to use, create a new facotry class inherient this class an add implement in create method
    abstract class MarioFactory 
    {
        protected Random random;

        protected MarioFactory()
        {
            random = new Random(DateTime.Now.Millisecond);
        }
        public abstract ISprite CreateMario(Game1 game, Vector2 pos, SpriteEffects ori);

    }


    // player one factory or mario factory
    // generate a new mario sprite
    class NormalMarioFactory : MarioFactory
    {
        private static MarioFactory instance;

        public static MarioFactory Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new NormalMarioFactory();
                }
                return instance;
            }
        }

        public override ISprite CreateMario(Game1 game, Vector2 pos,SpriteEffects ori)
        {
            return new NormalMarioStandingSprite(game,pos,ori);
        }
    }



    // player one factory or mario factory
    // generate a new mario sprite
    class FireMarioFactory : MarioFactory
    {
        private static MarioFactory instance;

        public static MarioFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FireMarioFactory();
                }
                return instance;
            }
        }

        public override ISprite CreateMario(Game1 game, Vector2 pos,SpriteEffects ori)
        {
            return new FireMarioStandingSprite(game, pos, ori);
        }
    }



    // player one factory or mario factory
    // generate a new mario sprite
    class SuperMarioFactory : MarioFactory
    {
        private static MarioFactory instance;

        public static MarioFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SuperMarioFactory();
                }
                return instance;
            }
        }

        public override ISprite CreateMario(Game1 game, Vector2 pos,  SpriteEffects ori)
        {
            return new SuperMarioStandingSprite(game, pos,ori);
        }
    }

    abstract class DMarioFactory
    {
        protected Random random;

        protected DMarioFactory()
        {
            random = new Random(DateTime.Now.Millisecond);
        }
        public abstract ISprite DeadMario(Game1 game, Vector2 postion);

    }

    class DeadMarioFactory : DMarioFactory
    {
        private static DeadMarioFactory instance;

        public static DeadMarioFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DeadMarioFactory();
                }
                return instance;
            }
        }

        public override ISprite DeadMario(Game1 game, Vector2 pos)
        {
            return new DeadMarioSprite(game, pos, SpriteEffects.None);
        }
    }

}
