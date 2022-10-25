using Microsoft.Xna.Framework;
using Sprint0.interfaces;
using Sprint0.Item;
using Sprint0.Sprites.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Sprites.factory
{
    public abstract class ItemSpriteFactory
    {
        public enum eItemType
        {
            Coin = 0,
            SuperMushroom = 1,
            FireFlower = 2,
            OneUpMushroom = 3,
            Star = 4,
            Pipe = 5,
            None = 6,
            Castle = 7,
            Fireball = 8,
        }
        protected ItemSpriteFactory()
        {
        }
        public abstract ISprite CreateItem(Game1 game, Vector2 pos, int type);

    }

    public class ItemFactory : ItemSpriteFactory
    {
        private static ItemFactory instance;

        public static ItemFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ItemFactory();
                }
                return instance;
            }
        }

        public override Sprite CreateItem(Game1 game, Vector2 pos, int type)
        {
            Sprite sprite = null;
            switch ((eItemType)type)
            {
                case eItemType.Coin:
                    sprite = new CoinSprite(game, pos);
                    break;
                case eItemType.SuperMushroom:
                    sprite = new SuperMushroomSprite(game, pos);
                    break;
                case eItemType.FireFlower:
                    sprite = new FireFlowerSprite(game, pos);
                    break;
                case eItemType.OneUpMushroom:
                    sprite = new OneUpMushroomSprite(game, pos);
                    break;
                case eItemType.Star:
                    sprite = new StarSprite(game, pos);
                    break;
                case eItemType.Pipe:
                    sprite = new PipeSprite(game, pos);
                    break;
                case eItemType.Castle:
                    sprite = new CastleSprite(game, pos);
                    break;
                case eItemType.Fireball:
                    sprite = new FireballSprite(game, pos);
                    break;
            }
            return sprite;
        }
    }
}


