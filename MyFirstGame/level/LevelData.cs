using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint0.State.BlockEntity;

namespace Sprint0.level
{
    public class LevelData
    {
        public List<LevelObject> ObjectData { get; private set; }
        public int LevelHeight { get; private set; }
        public int LevelWidth { get; private set; }
        public void SetObjectData(List<LevelObject> value)
        {
            ObjectData = value;
        }
        public LevelData()
        {
            SetObjectData(new List<LevelObject>());
        }


        public class LevelObject
        {
            public String ObjectType { get; set; }
            public String ObjectName { get; set; }
            public Vector2 Position { get; set; } 
            public BlockItemType  BlockItemType { get; set; }
            public int Lives { get; set; }
            

        }
    }
}
