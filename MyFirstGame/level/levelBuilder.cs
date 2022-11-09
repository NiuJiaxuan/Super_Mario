using Microsoft.Xna.Framework;
using System;
using Sprint0.level;
using System.Xml;
using static Sprint0.level.LevelData;
using System.Diagnostics;
using Sprint0.ScoreSystem;

namespace Sprint0.level
{
    public class LevelBuilder
    {
        public EntityStorage EntityStorage
        {
            get { return  EntityStorage.Instance; }
        }

        private static LevelBuilder instance;
        public static LevelBuilder Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LevelBuilder();
                }
                return instance;
            }
        }
        public LevelBuilder()
        {
        }

        public bool hidden = false;
        string file = "MarioLevel1.xml";
        public LevelData LevelData { get; private set; }

        public void LodeLevel (Game1 game, string file)
        {
            using (XmlReader levelFile = XmlReader.Create(file))
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
                        levelObject.BlockItem = items;
                        if (levelObject.ObjectName.Equals("Pipe"))
                        {
                            levelFile.ReadToNextSibling("BlockEnemy");
                            temp = levelFile.ReadElementContentAsString();
                            string[] enemies = temp.Split(' ');
                            levelObject.EnemyItem = enemies;
                            levelFile.ReadToNextSibling("Warp");
                            temp = levelFile.ReadElementContentAsString();
                            levelObject.Warp = temp;

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

