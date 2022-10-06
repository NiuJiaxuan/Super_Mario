using Microsoft.Xna.Framework;
using Sprint0.Enemy;
using Sprint0.interfaces;
using Sprint0.Sprites.useless;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Sprites
{
    public abstract class EnemySpriteFactory
    {
        protected EnemySpriteFactory()
        {

        }
        public abstract ISprite CreateGoomba(Game1 game, Vector2 pos);
        public abstract ISprite CreateKoopaTroopa(Game1 game, Vector2 pos);

    }

    public class EnemyFactory : EnemySpriteFactory
    {
        private static EnemyFactory instance;

        public static EnemyFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EnemyFactory();
                }
                return instance;
            }
        }

        public override ISprite CreateGoomba(Game1 game, Vector2 pos)
        {
            Sprite sprite = null;
            sprite = new GoombaSprite(game, pos);
            return sprite;
        }

        public override ISprite CreateKoopaTroopa(Game1 game, Vector2 pos)
        {
            Sprite sprite = null;
            sprite = new KoopaTroopSprite(game, pos);
            return sprite;
        }
    }
}
