using Microsoft.Xna.Framework;
using Sprint0.Enemy;
using Sprint0.interfaces;
using Sprint0.Sprites.Sprites;
using Sprint0.Sprites.useless;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Sprites.factory
{
    public abstract class EnemySpriteFactory
    {
        public enum eEnemeyType
        {
            Goomba = 1,
            KoopaTroopa = 2,
            DeadGooma = 3,
            IdleDeadKoopaTroopa = 4,
            Piranha = 6,
        }

        protected EnemySpriteFactory()
        {
        }

        public abstract ISprite CreateEnemy(Game1 game, Vector2 pos, int type);

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

        public override Sprite CreateEnemy(Game1 game, Vector2 pos, int type)
        {
            Sprite sprite = null;
            switch ((eEnemeyType)type)
            {
                case eEnemeyType.Goomba:
                    sprite = new GoombaSprite(game, pos);
                    break;
                case eEnemeyType.KoopaTroopa:
                    sprite = new KoopaTroopSprite(game, pos);
                    break;
                case eEnemeyType.DeadGooma:
                    sprite = new GoombaInjuredSprite(game, pos);
                    break;
                case eEnemeyType.IdleDeadKoopaTroopa:
                    sprite = new IdleKoopaTroopaInjuredSprite(game, pos);
                    break;
                case eEnemeyType.Piranha:
                    sprite = new PiranhaSprite(game, pos);
                    break;
            }
            return sprite;
        }
    }
}
