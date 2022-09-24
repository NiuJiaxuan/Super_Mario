using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Sprites
{
    //Abstract sprite factory class
    // to use, create a new facotry class inherient this class an add implement in create method
    abstract class SpriteFactory 
    {
        protected Random random;

        protected SpriteFactory()
        {
            random = new Random(DateTime.Now.Millisecond);
        }
        public abstract Sprite Create(Game1 game, Vector2 postion);
    }


    // player one factory or mario factory
    // generate a new mario sprite
    class PlayerOneAvatarFactory : SpriteFactory
    {
        private static SpriteFactory instance;

        public static SpriteFactory Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new PlayerOneAvatarFactory();
                }
                return instance;
            }
        }

        public override Sprite Create(Game1 game, Vector2 pos)
        {
            return new MarioSprite(game,pos );
        }
    }





}
