using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        public static CollisionDetector Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new CollisionDetector();
                }
                return instance;
            }
        }


        private GraphicsDeviceManager graphicsDevice { get; set; }
        private List<Grid> surroundingGrids { get; set; }


        public CollisionDetector()
        {
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
        public void DectectCollision()
        {            
            
            // create a new list to test collision
            List<Entity> collidables = new List<Entity>();
            collidables.AddRange(EntityStorage.Instance.EntityList);

            List<Entity> movables = EntityStorage.Instance.MovableEntities;

            //list of collision pairs (entity1, entity2, time, position)
            List<(Entity,Entity, float, Vector2, Touching,Touching)> currentCollisions = new List<(Entity,Entity,float, Vector2, Touching, Touching)>();

            for(int i =0; i< movables.Count(); i++)
            { 
                Entity movable = movables[i];
                //only test moving objects
                if(movable.Speed != Vector2.Zero || movable.Accelation != Vector2.Zero)
                {
                    //Debug.WriteLine("current moving entity: " + collidable);

                    //step 6: go back to step 1 for collided objects
                    while (true)
                    {
                        //step 1: get the surrounding entity list
                        collidables.Remove(movable);

                        List<Entity> surroundings = getSurroundingEntities(movable.SurroundingGrids, collidables);

                        //Debug.WriteLine(surroundings.Count);

                        surroundings.Remove(movable);

                        //step 2: find collisions
                        currentCollisions = Collsion(movable, surroundings);
                        
                        //Debug.WriteLine("total collisions: "+ currentCollisions.Count);

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



        public List<(Entity, Entity, float, Vector2, Touching, Touching)> Collsion(Entity collidable, List<Entity> entities)
        {
            Touching e1touching = Touching.none;
            Touching e2touching = Touching.none;
            Rectangle interactionRec;
            float x = collidable.Position.X, y = collidable.Position.Y;
            Entity collide;

            List<(Entity, Entity, float, Vector2, Touching, Touching)> result = new List<(Entity, Entity, float, Vector2, Touching, Touching)>();
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
                            e1touching = Touching.top;
                            e2touching = Touching.bottom;
                            y += interactionRec.Height;
                        }
                        else
                        {
                            e1touching = Touching.bottom;
                            e2touching = Touching.top;
                            y -= interactionRec.Height;
                        }
                        timePercent = interactionRec.Height / Math.Abs(collidable.Speed.Y);
                    }
                    else
                    {
                        if (collidable.GetRectangle.X < entity.GetRectangle.X)
                        {
                            e1touching = Touching.right;
                            e1touching = Touching.left;
                            x -= interactionRec.Width;
                        }
                        else
                        {
                            e1touching = Touching.left;
                            e2touching = Touching.right;
                            x += interactionRec.Width;
                        }
                        timePercent = interactionRec.Width / Math.Abs(collidable.Speed.X);
                    }
                    //Debug.WriteLine(touching);
                    //Debug.WriteLine("collide with "+ entity);
                    result.Add((collidable, entity, timePercent, new Vector2(x, y),e1touching, e2touching));
                }

            }
            return result;
        }


        public void CollsionResponse(List<(Entity, Entity, float, Vector2, Touching,Touching)> currentCollisions)
        {
            List<Entity> responsedEntities = new List<Entity>();
            for(int i = 0; i < currentCollisions.Count; i++)
            {
                if (!responsedEntities.Contains(currentCollisions[i].Item1))
                {
                    //Debug.WriteLine(currentCollisions[i].Item1);
                    //Debug.WriteLine(currentCollisions[i].Item2);

                    responsedEntities.Add(currentCollisions[i].Item1);
                    currentCollisions[i].Item2.CollisionResponse(currentCollisions[i].Item1, currentCollisions[i].Item4, currentCollisions[i].Item6);
                    currentCollisions[i].Item1.CollisionResponse(currentCollisions[i].Item2, currentCollisions[i].Item4, currentCollisions[i].Item5);
                }
            }
        }


        public void Update()
        {


        }

        public void Draw(SpriteBatch batch)
        {

        }
    }
}

public class TimeComparer : IComparer<(Entity, Entity, float,Vector2, CollisionDetector.Touching, CollisionDetector.Touching)>
{
    public int Compare((Entity, Entity, float, Vector2, CollisionDetector.Touching, CollisionDetector.Touching) e1, (Entity, Entity, float, Vector2, CollisionDetector.Touching, CollisionDetector.Touching) e2)
    {
        return e1.Item3.CompareTo(e2.Item3);
    }
}
