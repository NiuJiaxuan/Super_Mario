using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Item
{
    public class CoinEntity : ItemEntity
    {
        public CoinEntity(Game1 game, Vector2 position)
            : base(game, position)
        {
            ItemType = eItemType.Coin;
            Sprite = ItemSpriteFactory.CreateItem(game, position, ItemType);
        }
    }

    public CoinEntity(Game1 game, Sprite sprite)
             : base(game, sprite)
    {
        ItemType = eItemType.Coin;
    }
}
