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
    public class Collision
    {
        public enum Touching
        {
            left,
            right,
            top,
            bottom,
            none
        }

        private Entity currentEntity;

        public Collision(Entity currentEntity)
        {
            this.currentEntity = currentEntity;
        }

        public Tuple<Touching, float , float > detectCollsion(List<Entity> entities)
        {
            Touching touching = Touching.none;
            Rectangle interactionRec;
            float x = currentEntity.Position.X , y = currentEntity.Position.Y;

            Tuple<Touching, float, float> result;
            foreach(Entity entity in entities)
            {
                interactionRec = Rectangle.Intersect(currentEntity.GetRectangle, entity.GetRectangle);
                if (!interactionRec.IsEmpty)
                {
                    Debug.WriteLine(currentEntity + " collied with " + entity);
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
                        if(currentEntity.GetRectangle.X< entity.GetRectangle.X)
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
                }

            }
            result = new Tuple<Touching, float, float>(touching, x, y);
            return result;
        }

    }
}
