using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Block.State;
using Sprint0.CollisionDetection;
using Sprint0.Item;
using Sprint0.Enemy;

using Sprint0.Interfaces;
using System.Diagnostics;
using System.Numerics;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using Sprint0.Mario;

namespace Sprint0.Block
{
    public class PipeEntity : BlockEntity, IStaticEntity
    {
        public List<ItemEntity> BlockItemList;
        public List<EnemyEntity> BlockEnemyList;
        public List<Entity> EntityList;
        int time;
        bool plant;
        public Vector2 WarpPosition;
        string HiddenMap;
        
        public PipeEntity(Game1 game, Vector2 position, List<ItemEntity> blockItemList, List<Entity> entityList, List<EnemyEntity> blockEnemyList, String warp)
            : base(game, position)
        {
            time = 0;
            BlockType =  eBlockType.Pipe;
            Sprite = BlockFactory.CreateBlock(game, position, (int)BlockType);
            BlockItemList = blockItemList;
            BlockEnemyList = blockEnemyList;
            EntityList = entityList;
            plant = false;

            if (warp.Contains(".xml"))
            {
                HiddenMap = warp;
                WarpPosition = position;
            }
            else if(warp.Length != 0) 
            {
                string[] temp = warp.Split(' ');
                WarpPosition = new Vector2(Int32.Parse(temp[0]), Int32.Parse(temp[1]) - 60);
            }
            //Vector2 pos = new Vector2((int)position.X, (int)position.Y - 200);
            //PiranhaPlant = new PiranhaEntity(game, pos);
        }
        public override void CollisionResponse(Entity entity, Vector2 position, CollisionDetector.Touching touching)
        {
            //switch(entity)
            //{
            //    case MarioEntity:
            //        if (touching == CollisionDetector.Touching.top)
            //        {
            //            Debug.WriteLine("TOP - Pipe");
            //            Debug.WriteLine(WarpPosition.ToString());
            //            Debug.WriteLine("X:" + EntityStorage.Instance.Mario.Position.X);
            //            EntityStorage.Instance.Mario.Position = WarpPosition;
            //        }
            //        break;
            //}
        }
        public override void Update(GameTime gameTime, List<Entity> entities)
        {
            if (Math.Abs(Position.X - EntityStorage.Instance.Mario.Position.X) < 400 && Math.Abs(Position.X - EntityStorage.Instance.Mario.Position.X) > 100)
            {
                time++;
                //Debug.WriteLine(time);
                //if (BlockItemList.Count != 0)
                //{
                //    if(time % 300 == 0)
                //    { 
                //        if (!plant)
                //        {
                //            ItemEntity temp = BlockItemList[0];
                //            EntityList.Add(temp);
                //            temp.BumpTransition();
                //            BlockItemList.RemoveAt(0);
                //        }
                //    }
                //}
                if(BlockEnemyList.Count != 0)
                {
                    EnemyEntity temp = BlockEnemyList[0];
                    if (time % 500 == 0)
                    {
                        plant = true;
                        EntityList.Add(temp);
                        string dir = "up";
                        temp.EmergeTransition(dir);
                    }
                    else if(time % 700 == 0)
                    {
                        string dir = "down";
                        temp.EmergeTransition(dir);
                        EntityList.Remove(temp);
                        BlockEnemyList.RemoveAt(0);

                    }
                }
            }
            //else if (Position.X - EntityStorage.Instance.Mario.Position.X < -350)
            //{
            //}
            //else if (Position.Y > 480)
            //{
            //}
            base.Update(gameTime, entities);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }


    }
}
