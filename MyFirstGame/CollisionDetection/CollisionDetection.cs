using Microsoft.Xna.Framework;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.CollisionDetection
{
    public class CollisionDetection
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

        public CollisionDetection(Entity currentEntity)
        {
            this.currentEntity = currentEntity;
        }

        public Touching detectCollsion(List<Entity> entities)
        {
            Touching touching = Touching.none;
            Rectangle interactionRec;
            foreach(Entity entity in entities)
            {
                interactionRec = Rectangle.Intersect(currentEntity.GetRectangle, entity.GetRectangle);


            }
            return touching;
        }

    }
}
