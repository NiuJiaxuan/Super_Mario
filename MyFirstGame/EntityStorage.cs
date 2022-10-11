using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Block;
using Sprint0.Enemy;
using Sprint0.Item;
using Sprint0.level;
using Sprint0.Mario;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint0.level.LevelData;

namespace Sprint0
{
    public class EntityStorage
    {
        public List<Entity> BackgroundEntityList { get; set; }
        public List<Entity> BlockEntityList { get; set; }
        public List<Entity> ItemEntityList { get; set; }
        public List<Entity> EnemyEntityList { get; set; }

        public List<Entity> EntityList { get; set; }

        public List<Entity> PlayerList { get; set; }

        public static EntityStorage Instance { get; } = new EntityStorage();
        public Entity Mario { get; set; } 

        public  EntityStorage()
        {

        }

        public void SetEntityList(List<Entity> value)
        {
            EntityList = value;
        }
        public void SetPlayerList (List<Entity> value)
        {
            PlayerList = value; 
        }

        private static Entity CreateEntity(LevelObject levelObject, Game1 game)
        {
            string objectType = levelObject.ObjectType;
            string objectName = levelObject.ObjectName;
            if (objectType.Equals("Blocks"))
            {
                if (objectName.Equals("BrickBlock")){
                    return new BrickBlockEntity(game, levelObject.Position, true);
                }
                else if (objectName.Equals("QuestionBlock"))
                {
                    return new QuestionBlockEntity(game, levelObject.Position,true);
                }
                else if (objectName.Equals("HiddenBrickBlock"))
                {
                    return new BrickBlockEntity(game, levelObject.Position, false);
                }
                else if (objectName.Equals("HiddenQuestionBlock"))
                {
                    return new QuestionBlockEntity(game, levelObject.Position, false);
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

        public void  Add (LevelData levelData, Game1 game)
        {
            BackgroundEntityList = new List<Entity>();
            BlockEntityList = new List<Entity>();
            ItemEntityList = new List<Entity>();
            EnemyEntityList = new List<Entity>();

            SetEntityList(new List<Entity>());
            SetPlayerList(new List<Entity>());

            foreach (LevelObject levelObject in levelData.ObjectData)
            {
                Entity entity = CreateEntity(levelObject, game);
                EntityList.Add(entity);
                switch (levelObject.ObjectType)
                {
                    case "Mario":
                        Mario = entity;
                        EntityList.Remove(Mario); 
                        break;
                    case "Block":
                        BlockEntityList.Add(entity);
                        break;
                    case "Item":
                        ItemEntityList.Add(entity); ;
                        break;
                    case "Enemy":
                        EnemyEntityList.Add(entity);
                        break;
                }

                //if (!levelObject.ObjectType.Equals("Mario"))
                //{
                //    Entity entity = CreateEntity(levelObject, game);
                //    EntityList.Add(entity);
                //}
                //else
                //{
                //    Mario = CreateEntity(levelObject, game);
                //    PlayerList.Add(Mario);
                //}
            }
        }

        public void Update(GameTime gameTime)
        {

            Mario.Update(gameTime,EntityList,ItemEntityList,EnemyEntityList);
            foreach (Entity entity in BlockEntityList)
            {
                entity.Update(gameTime, (MarioEntity)Mario, EnemyEntityList);
            }
            foreach (Entity entity1 in ItemEntityList)
            {
                entity1.Update(gameTime);
            }
            foreach (Entity entity2 in EnemyEntityList)
            {
                entity2.Update(gameTime, (MarioEntity)Mario, BlockEntityList);
            }
        }
        public void Draw(SpriteBatch batch)
        {
            Mario.Draw(batch);
            foreach (Entity entity in EntityList)
            {
                entity.Draw(batch);
            }
        }
    }
}
