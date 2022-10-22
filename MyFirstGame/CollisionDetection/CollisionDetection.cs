using Microsoft.Xna.Framework;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
                if (instance == null)
                {
                    instance = new CollisionDetector();
                }
                return instance;
            }
        }

        public Entity currentEntity;
        private EntityStorage storage;

        public CollisionDetector()
        {
            SetupGrids();
        }




        public Tuple< Touching, float , float, Entity > Collsion(List<Entity> entities)
        {
            Touching touching = Touching.none;
            Rectangle interactionRec;
            float x = currentEntity.Position.X , y = currentEntity.Position.Y;
            Entity collide = null;

            Tuple< Touching, float, float,Entity> result;
            foreach(Entity entity in entities)
            {
                interactionRec = Rectangle.Intersect(currentEntity.GetRectangle, entity.GetRectangle);
                if (!interactionRec.IsEmpty)
                {
                    collide = entity;

                    //Debug.WriteLine(currentEntity + " collied with " + entity);

                    if(interactionRec.Width >= interactionRec.Height)
                    {
                        if(currentEntity.GetRectangle.Y > entity.GetRectangle.Y)
                        {
                            touching = Touching.top;
                            y += interactionRec.Height;
                        }
                        else
                        {
                            touching = Touching.bottom;
                            y -= interactionRec.Height;
                        }
                    }
                    else
                    {
                        if(currentEntity.GetRectangle.X < entity.GetRectangle.X)
                        {
                            touching = Touching.right;
                            x-= interactionRec.Width;
                        }
                        else
                        {
                            touching = Touching.left;
                            x+= interactionRec.Width;
                        }
                    }
                    //Debug.WriteLine(touching);

                }

            }
            result = new Tuple<Touching, float, float,Entity>(touching, x, y,collide);
            return result;
        }

        public void SetupGrids()
        {
            Entity[,] grids;


        }

        public List<Grid> getSurroundingGrids(Entity entity)
        {
            List<Grid> surroundingGrids = new List<Grid>();
            foreach
        }

        public void DectectCollision(List<Entity> entities)
        {
            List<Entity> collidables = new List<Entity>();
            collidables.AddRange(entities);
            foreach(Entity collidable in collidables)
            {
                collidables.Remove(collidable);

                
            }
        }

    }
}
