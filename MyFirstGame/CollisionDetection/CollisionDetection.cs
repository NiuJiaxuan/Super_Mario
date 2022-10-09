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
        }

        public CollisionDetection()
        {

        }

        public Touching detectCollsion()
        {



            return Touching.top;
        }

    }
}
