using Microsoft.Xna.Framework;
using Sprint0.CollisionDetection;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.CollisionDetection
{
    public class CollisionDetector
    {
        public enum Touching
        {
            left,
            right,
            top,
            bottom,
            none
        }

        private static CollisionDetector instance;
        public static CollisionDetector Instance(GraphicsDeviceManager graphics)
        {

                if (instance == null)
                {
                    instance = new CollisionDetector(graphics);
                }
                return instance;
        }


        private GraphicsDeviceManager graphicsDevice { get; set; }
        private Grid[,] AllGrids { get; set; }

        public CollisionDetector(GraphicsDeviceManager graphics)
        {
            graphicsDevice = graphics;
            SetupGrids();
        }


        public void SetupGrids()
        {
            int x = graphicsDevice.PreferredBackBufferHeight;
            int y = graphicsDevice.PreferredBackBufferWidth;

            AllGrids = new Grid[x/33,y/33];
            for(int i = 0; i < x/33; i++)
            {
                for(int j = 0; j < y/33; j++)
                {
                    AllGrids[i, j] = new Grid(new Vector2(33 * i, 33 * j), new Vector2(33, 33));
                }
            }

        }

        public List<Grid> getSurroundingGrids(Entity entity)
        {
            List<Grid> surroundingGrids = new List<Grid>();
            foreach (Grid grid in AllGrids)
            {
                if (grid.Rectangle.Intersects(entity.GetRectangle))
                {
                    surroundingGrids.Add(grid);
                }
            }

            return surroundingGrids;
        }

        public List<Entity> getSurroundingEntities(List<Grid> grids, List<Entity> entities)
        {
            List<Entity> surroundingEntities = new List<Entity>();
            foreach(Grid grid in grids)
            {
                foreach(Entity entity in entities)
                {
                    if(entity.GetRectangle.Intersects(grid.Rectangle))
                        surroundingEntities.Add(entity);
                }
            }

            return surroundingEntities;
        }

        //this entity list only contains entities with in the same grids with target moving entities. 
        public void DectectCollision(List<Entity> entities)
        {            
            // create a new list to test collision
            List<Entity> collidables = new List<Entity>();
            collidables.AddRange(entities);

            //list of collision pairs (entity1, entity2, time, position)
            List<(Entity,Entity, float, Vector2, Touching)> currentCollisions = new List<(Entity,Entity,float, Vector2, Touching)>();

            foreach (Entity collidable in collidables)
            {
                //only test moving objects
                if(collidable.Speed != Vector2.Zero || collidable.Accelation != Vector2.Zero)
                {
                    //step 6: go back to step 1 for collided objects
                    while (true)
                    {
                        //step 1: get the surrounding entity list
                        collidables.Remove(collidable);
                        List<Entity> surroundings = getSurroundingEntities(getSurroundingGrids(collidable), collidables);
                        surroundings.Remove(collidable);

                        //step 2: find collisions
                        currentCollisions = Collsion(collidable, surroundings);
                        //step 7: if not collisions, quit
                        if(currentCollisions.Count == 0)
                        {
                            break;
                        }
                        //step 3: sort collisions based on time
                        currentCollisions.Sort(new TimeComparer());
                        //step 4 & 5: update position and speed
                        CollsionResponse(currentCollisions);
                    }
                }
            }
        }



        public List<(Entity, Entity, float, Vector2, Touching)> Collsion(Entity collidable, List<Entity> entities)
        {
            Touching touching = Touching.none;
            Rectangle interactionRec;
            float x = collidable.Position.X, y = collidable.Position.Y;
            Entity collide;

            List<(Entity, Entity, float, Vector2, Touching)> result = new List<(Entity, Entity, float, Vector2, Touching)>();
            float timePercent ;

            foreach (Entity entity in entities)
            {
                interactionRec = Rectangle.Intersect(collidable.GetRectangle, entity.GetRectangle);
                if (!interactionRec.IsEmpty)
                {
                    collide = entity;

                    //Debug.WriteLine(currentEntity + " collied with " + entity);

                    if (interactionRec.Width >= interactionRec.Height)
                    {
                        if (collidable.GetRectangle.Y > entity.GetRectangle.Y)
                        {
                            touching = Touching.top;
                            y += interactionRec.Height;
                        }
                        else
                        {
                            touching = Touching.bottom;
                            y -= interactionRec.Height;
                        }
                        timePercent = interactionRec.Height / Math.Abs(collidable.Speed.Y);
                    }
                    else
                    {
                        if (collidable.GetRectangle.X < entity.GetRectangle.X)
                        {
                            touching = Touching.right;
                            x -= interactionRec.Width;
                        }
                        else
                        {
                            touching = Touching.left;
                            x += interactionRec.Width;
                        }
                        timePercent = interactionRec.Width / Math.Abs(collidable.Speed.X);
                    }
                    //Debug.WriteLine(touching);
                    result.Add((collidable, entity, timePercent, new Vector2(x, y),touching));
                }

            }
            return result;
        }


        public void CollsionResponse(List<(Entity, Entity, float, Vector2, Touching)> currentCollisions)
        {
            List<Entity> responsedEntities = new List<Entity>();
            for(int i = 0; i < currentCollisions.Count; i++)
            {
                if (!responsedEntities.Contains(currentCollisions[i].Item1))
                {
                    responsedEntities.Add(currentCollisions[i].Item1);
                    currentCollisions[i].Item1.CollisionResponse(currentCollisions[i].Item2, currentCollisions[i].Item4, currentCollisions[i].Item5);
                    currentCollisions[i].Item2.CollisionResponse(currentCollisions[i].Item1, currentCollisions[i].Item4, currentCollisions[i].Item5);
                }
            }
        }


        public void Update()
        {


        }

        public void draw()
        {

        }
    }
}

public class TimeComparer : IComparer<(Entity, Entity, float,Vector2, CollisionDetector.Touching)>
{
    public int Compare((Entity, Entity, float, Vector2, CollisionDetector.Touching) e1, (Entity, Entity, float, Vector2, CollisionDetector.Touching) e2)
    {
        return e1.Item3.CompareTo(e2.Item3);
    }
}
