using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Block;
using Sprint0.Block.State.GameState;
using Sprint0.CollisionDetection;
using Sprint0.Command;
using Sprint0.Controller;
using Sprint0.Enemy;
using Sprint0.interfaces;
using Sprint0.Interfaces;
using Sprint0.Item;
using Sprint0.level;
using Sprint0.Mario;
using Sprint0.ScoreSystem;
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
        public bool isPause = false, gameOver=false;
        public List<Entity> DrawableEntities { get; set; }
        public List<Entity> EntityList { get; set; }
        public List<Entity> MovableEntities { get; set; }
        public List<Entity> ColliableEntites { get; set; }
        public List<Entity> GravityEntites { get; set; }

        //public List<Entity> PlayerList { get; set; }
        public MarioEntity Mario { get; set; }

        private IController keyboard;
        private IController pausedKeyboard;
        private IController gameOverKeyboard;
        public Game1 Game { get; set; }

        public List<Vector2> checkPoints;
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

        public void initialCheckPoints()
        {
            checkPoints = new List<Vector2>();
            checkPoints.Add(new Vector2(0, 100));
            checkPoints.Add(new Vector2(500,100));
            checkPoints.Add(new Vector2(1000, 100));
            checkPoints.Add(new Vector2(1500, 100));
            checkPoints.Add(new Vector2(2000, 100));
            checkPoints.Add(new Vector2(2500, 100));
            checkPoints.Add(new Vector2(3000, 100));
            checkPoints.Add(new Vector2(3500, 100));
            checkPoints.Add(new Vector2(4000, 100));
        }

        public  EntityStorage()
        {
            EntityList = new List<Entity>();
            MovableEntities = new List<Entity>();
            ColliableEntites = new List<Entity>();
            GravityEntites = new List<Entity>();
            DrawableEntities = new List<Entity>();
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
                else if (objectName.Equals("Flagpole"))
                {
                    return new FlagPoleEntity(game, levelObject.Position);
                }
                else if (objectName.Equals("Flag"))
                {
                    return new FlagEntity(game, levelObject.Position);
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

        public void newEneityAdd(Entity entity)
        {
            EntityList.Add(entity);
            MovableEntities.Add(entity);
            ColliableEntites.Add(entity);
            GravityEntites.Add(entity);
            Grid.Instance.AddEntity(entity);
        }

        public void completeRemove(Entity entity)
        {
            EntityList.Remove(entity);
            MovableEntities.Remove(entity);
            ColliableEntites.Remove(entity);
            GravityEntites.Remove(entity);
            Grid.Instance.RemoveEntity(entity);
        }

        public void movableRemove(Entity entity)
        {
            MovableEntities.Remove(entity);
            GravityEntites.Remove(entity);
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
                    Mario = (MarioEntity)entity;
                }
                if (entity is IMovableEntity)
                    MovableEntities.Add(entity);

                if (entity is IGravityEntity)
                    GravityEntites.Add(entity);

                Grid.Instance.AddEntity(entity);
            }       
        }

        public void initialCommand(Game1 game)
        {
            keyboard = new KeyboardController();
            keyboard.Command((int)Keys.Q, new ExitCommand(game));
            keyboard.Command((int)Keys.R, new ResetCommand(game));
            keyboard.Command((int)Keys.P, new PauseCommand(this));
            keyboard.Command((int)Keys.I, new ChangeToFireMario(Mario));
            keyboard.Command((int)Keys.Space, new ShootingFireballCommand(Mario));
            keyboard.Command((int)Keys.U, new ChangeToSuperMario(Mario));
            keyboard.Command((int)Keys.Y, new ChangeToNormalMario(Mario));
            keyboard.Command((int)Keys.O, new MarioTakeDamege(Mario));

            keyboard.Command((int)Keys.M, new MuteCommand(SoundStorage.Instance)); 

            keyboard.Command((int)Keys.W, new MarioJump(Mario));
            keyboard.Command((int)Keys.Up, new MarioJump(Mario));

            keyboard.Command((int)Keys.S, new MarioCrouch(Mario));
            keyboard.Command((int)Keys.Down, new MarioCrouch(Mario));

            keyboard.Command((int)Keys.A, new MarioWalkLeft(Mario));
            keyboard.Command((int)Keys.Left, new MarioWalkLeft(Mario));

            keyboard.Command((int)Keys.D, new MarioWalkRight(Mario));
            keyboard.Command((int)Keys.Right, new MarioWalkRight(Mario));

            keyboard.Command((int)Keys.C, new ShowBoundBox(EntityStorage.Instance.EntityList));

            gameOverKeyboard = new KeyboardController();
            gameOverKeyboard.Command((int)Keys.Q, new ExitCommand(game));
            gameOverKeyboard.Command((int)Keys.R, new ResetCommand(game));
        }
        public void Update(GameTime gameTime)
        {
            if (!isPause&&!gameOver)
            {
                foreach (Entity entity in ColliableEntites)
                {
                    if (!EntityList.Contains(entity))
                    {
                        EntityList.Add(entity);
                    }
                }
                keyboard.Update();
                for (int i = 0; i < EntityList.Count; i++)
                {
                    EntityList[i].Update(gameTime, EntityList);
                }
            //synchronize entity list
            foreach(Entity entity in ColliableEntites)
            {
                if (!EntityList.Contains(entity))
                {
                    EntityList.Add(entity);
                }
            }

            for (int i = 0; i< EntityList.Count; i++)
            {
                EntityList[i].Update(gameTime, EntityList);
            }

                CollisionDetector.Instance.DectectCollision();
            }
            else if(isPause)
            {
                pausedKeyboard.Update();
            }
            else if (gameOver)
            {

                gameOverKeyboard.Update();
            }
            
        }
        public void PauseCommand()
        {
            isPause = !isPause;
            pausedKeyboard = new KeyboardController();
            pausedKeyboard.Command((int)Keys.Q, new ExitCommand(Game));
            pausedKeyboard.Command((int)Keys.P, new PauseCommand(this));
            HUD.Instance.isPasued = !HUD.Instance.isPasued;
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
