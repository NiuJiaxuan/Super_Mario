using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using Sprint0.level;
using System.Xml;
using static Sprint0.level.LevelData;
using static Sprint0.State.BlockEntity;
using System.Diagnostics;

namespace Sprint0.Sprites
{
    public class LevelBuilder
    {
        public LevelData LevelData { get; private set; }
        public void LodeLevel (Game1 game)
        {
            using (XmlReader levelFile = XmlReader.Create("Content/MarioLevel.xml"))
            {
                levelFile.ReadToFollowing("LevelHeight");
                int levelHeight = levelFile.ReadElementContentAsInt();
                levelFile.ReadToNextSibling("LevelWidth");
                int levelWidth = levelFile.ReadElementContentAsInt();
                LevelData = new LevelData(levelHeight, levelWidth);
                levelFile.ReadToFollowing("ObjectData");
                while (!levelFile.EOF)
                {
                    LevelObject levelObject = new LevelObject();
                    levelFile.ReadToDescendant("ObjectType");
                    levelObject.ObjectType = levelFile.ReadElementContentAsString();
                    Debug.WriteLine(levelObject.ObjectType);
                    levelFile.ReadToDescendant("ObjectName");
                    levelObject.ObjectName = levelFile.ReadElementContentAsString();
                    levelFile.ReadToDescendant("Position");
                    string location = levelFile.ReadElementContentAsString();
                    int i = location.IndexOf(' ');
                    int xPos = int.Parse(location.Substring(0, i));
                    int yPos = int.Parse(location.Substring(i));
                    levelObject.Position = new Vector2(xPos, yPos);
                    if (levelObject.ObjectType == "Blocks")
                    {
                        levelFile.ReadToNextSibling("BlockItemType");
                        levelObject.BlockItemType = (BlockItemType)Enum.Parse(typeof(BlockItemType), levelFile.ReadElementContentAsString());
                    }
                    if (levelObject.ObjectType.Equals("Mario"))
                    {
                        //levelFile.ReadToNextSibling("Lives");
                        //levelObject.Lives = levelFile.ReadElementContentAsInt();
                    }
                    LevelData.ObjectData.Add(levelObject);
                    levelFile.ReadToFollowing("Item");
                }
                
                
            }

            EntityStorage.Instance.Add(LevelData, game);
        }
    }
}

