using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Sprites
{
    public class MapDefinition 
    {
        public class StartData
        {
            public int xLocation;
            public int yLocation;
            public int yMax;
            public int xMax;
        }
        public class BlockData
        {
            public ISprite State;
            public ISprite itemType;
            public int xLocation;
            public int yLocation;
        }
        public class ItemData
        {
            public ISprite itemType;
            public int xLocation;
            public int yLocation;
        }

        public class EnemyData
        {
            public ISprite enemyType;
            public int xLocation;
            public int yLocation;
        }
    }
}
