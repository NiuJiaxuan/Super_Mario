using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Sprites
{
    abstract class SpriteFactory 
    {
        protected Random random;

        protected SpriteFactory()
        {
            random = new Random(DateTime.Now.Millisecond);
        }
        public abstract Sprite Create();
    }

    class PlayerOneAvatar : SpriteFactory
    {
        private static SpriteFactory instance;

        private static SpriteFactory Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new PlayerOneAvatar();
                }
                return instance;
            }
        }

        public override Sprite Create()
        {
            return new MarioSprite();
        }
    }



}
