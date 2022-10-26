using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Block;
using Sprint0.CollisionDetection;
using Sprint0.Enemy;
using Sprint0.Interfaces;
using Sprint0.Item;
using Sprint0.level;
using Sprint0.Mario;
using Sprint0.Sprites;
using Sprint0.State;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint0.level.LevelData;

namespace Sprint0
{
    public class EntityStorage
    {
        public List<Entity> EntityList { get; set; }
        public List<Entity> MovableEntities { get; set; }
        public List<Entity> ColliableEntites { get; set; }

        //public List<Entity> PlayerList { get; set; }
        public Entity Mario { get; set; }


        public Grid[,] AllGrids { get; set; }

        private static EntityStorage instance;
        public static EntityStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EntityStorage();
                }
                return instance;
            }
        }



        public  EntityStorage()
        {
            EntityList = new List<Entity>();
            MovableEntities = new List<Entity>();
            ColliableEntites = new List<Entity>();
        }

        public void SetupGrids(GraphicsDeviceManager graphicsDevice)
        {
            double y = 450;
            double x = 6000;

            int colunms =(int)Math.Ceiling(x / 33);
            int rows = (int)Math.Ceiling(y / 33);

            AllGrids = new Grid[colunms, rows];
            for (int i = 0; i < colunms; i++)
            {
                for (int j = 0; j <rows; j++)
                {
                    AllGrids[i, j] = new Grid(new Vector2(33 * i, 33 * j), new Vector2(33, 33));
                }
            }
        }

        private static Entity CreateEntity(LevelObject levelObject, Game1 game, List<Entity> entityList)
        {
            string objectType = levelObject.ObjectType;
            string objectName = levelObject.ObjectName;
            if (objectType.Equals("Blocks"))
            {
                List<ItemEntity> itemInBlock = CreateItemEntityInBlock(levelObject, game);
                if (objectName.Equals("BrickBlock")){
                    return new BrickBlockEntity(game, levelObject.Position, true, itemInBlock, entityList);
                }
                else if (objectName.Equals("QuestionBlock"))
                {
                    return new QuestionBlockEntity(game, levelObject.Position,true, itemInBlock, entityList);
                }
                else if (objectName.Equals("HiddenBrickBlock"))
                {
                    return new BrickBlockEntity(game, levelObject.Position, false, itemInBlock, entityList);
                }
                else if (objectName.Equals("HiddenQuestionBlock"))
                {
                    return new QuestionBlockEntity(game, levelObject.Position, false, itemInBlock, entityList);
                }
                else if (objectName.Equals("UsedBlock"))
                {
                    return new UsedBlockEntity(game, levelObject.Position);
                }
                else if (objectName.Equals("StairBlock"))
                {
                    return new StairBlockEntity(game, levelObject.Position);
                }
                else if (objectName.Equals("FloorBlock"))
                {
                    return new FloorBlockEntity(game, levelObject.Position);
                }
            }
            else if (objectType.Equals("Items"))
            {
              if (objectName.Equals("Coin"))
                {
                    return new CoinEntity(game, levelObject.Position);
                }
                else if (objectName.Equals("Star"))
                {
                    return new StarEntity(game, levelObject.Position);
                }
                else if (objectName.Equals("SuperMushroom"))
                {
                    return new SuperMushroomEntity(game, levelObject.Position);
                }
                else if (objectName.Equals("OneUpMushroom"))
                {
                    return new OneUpMushroomEntity(game, levelObject.Position);
                }
                else if (objectName.Equals("FireFlower"))
                {
                    return new FireFlowerEntity(game, levelObject.Position);
                }
                else if (objectName.Equals("Pipe"))
                {
                    return new PipeEntity(game, levelObject.Position);
                }
                else if (objectName.Equals("Castle"))
                {
                    return new CastleEntity(game, levelObject.Position);
                }
                else if (objectName.Equals("Flag"))
                {
                    return new FlagPoleEntity(game, levelObject.Position);
                }
            }
            else if (objectType.Equals("Enemies"))
            {
                if (objectName.Equals("Goomba"))
                {
                    return new GoombaEntity(game, levelObject.Position);
                }
                else if (objectName.Equals("KoopaTroopa"))
                {
                    return new KoopaTroopaEntity(game, levelObject.Position);
                }
            }
            else
            {
                return new MarioEntity(game, levelObject.Position);
            }
            return null;
        }

        private static List<ItemEntity> CreateItemEntityInBlock(LevelObject levelObject, Game1 game)
        {
            List<ItemEntity> temp = new List<ItemEntity>();
            if (levelObject.BlockItem != null)
            foreach (string item in levelObject.BlockItem)
            {
                if (item.Equals("Coin"))
                {
                    temp.Add(new CoinEntity(game, levelObject.Position));
                }
                else if (item.Equals("Star"))
                {
                    temp.Add(new StarEntity(game, levelObject.Position));
                }
                else if (item.Equals("FireFlower"))
                {
                    temp.Add(new FireFlowerEntity(game, levelObject.Position));
                }
                else if (item.Equals("OnUpMushroom"))
                {
                    temp.Add(new OneUpMushroomEntity(game, levelObject.Position));
                }
                else if (item.Equals("SuperMushroom"))
                {
                    temp.Add(new SuperMushroomEntity(game, levelObject.Position));
                }
            }
            return temp;
        }

        public void movableAdd(Entity entity)
        {
            EntityList.Add(entity);
            MovableEntities.Add(entity);
            ColliableEntites.Add(entity);
        }

        public void movableRemove(Entity entity)
        {
            EntityList.Remove(entity);
            MovableEntities.Remove(entity);
            ColliableEntites.Remove(entity);
        }

        public void  Add (LevelData levelData, Game1 game)
        {

            foreach (LevelObject levelObject in levelData.ObjectData)
            {
                Entity entity = CreateEntity(levelObject, game, ColliableEntites);
                EntityList.Add(entity);
                ColliableEntites.Add(entity);
                if (entity.GetType() == typeof(MarioEntity))
                {
                    Mario = entity;
                }
                if (entity is IMovableEntity)
                    MovableEntities.Add(entity);
            }
       
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {

            //synchronize entity list
            foreach(Entity entity in ColliableEntites)
            {
                if (!EntityList.Contains(entity))
                {
                    EntityList.Add(entity);
                }
            }
          
            for(int i = 0; i< EntityList.Count; i++)
            {
                    EntityList[i].Update(gameTime, EntityList);
            }

            CollisionDetector.Instance.DectectCollision();

        }
        public void clear()
        {
            EntityList.Clear();
            MovableEntities.Clear();
            ColliableEntites.Clear();
            Mario = null;
        }
        public void Draw(SpriteBatch batch)
        {
            foreach(Entity entity in EntityList)
            {
                entity.Draw(batch);
            }

            CollisionDetector.Instance.Draw(batch);

        }
    }
}
