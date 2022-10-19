using Microsoft.Xna.Framework;
using System;
using Sprint0.level;
using System.Xml;
using static Sprint0.level.LevelData;
using static Sprint0.State.BlockEntity;
using System.Diagnostics;

namespace Sprint0.level
{
    public class LevelBuilder
    {
        public EntityStorage EntityStorage { get; set; }

        public LevelBuilder()
        {
            EntityStorage = new EntityStorage();
        }

        public LevelData LevelData { get; private set; }

        public void LodeLevel (Game1 game)
        {
            using (XmlReader levelFile = XmlReader.Create("MarioLevel1.xml"))
            {
                LevelData = new LevelData();
                levelFile.ReadToFollowing("ObjectData");
                while (!levelFile.EOF)
                {
                    LevelObject levelObject = new LevelObject();
                    levelFile.ReadToDescendant("ObjectType");
                    levelObject.ObjectType = levelFile.ReadElementContentAsString();
                    levelFile.ReadToNextSibling("ObjectName");
                    levelObject.ObjectName = levelFile.ReadElementContentAsString();
                    levelFile.ReadToNextSibling("Position");
                    string location = levelFile.ReadElementContentAsString();
                    int i = location.IndexOf(' ');
                    int xPos = int.Parse(location.Substring(0, i));
                    int yPos = int.Parse(location.Substring(i));
                    levelObject.Position = new Vector2(xPos, yPos);
                    if (levelObject.ObjectType.Equals("Blocks"))
                    {
                        levelFile.ReadToNextSibling("BlockItem");
                        string temp = levelFile.ReadElementContentAsString();
                        string[] items = temp.Split(' ');
                        foreach (string item in items)
                        {
                            levelObject.BlockItem?.Add(item);
                        }
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

            EntityStorage.Add(LevelData, game);
        }
    }
}

