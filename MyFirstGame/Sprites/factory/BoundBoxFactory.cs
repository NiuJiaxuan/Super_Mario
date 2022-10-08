using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Sprites.factory
{
    public abstract class BoundBoxSpriteFactory
    {
        protected BoundBoxSpriteFactory()
        {

        }
        public abstract Sprite CreateBoundBox(Game1 game, Vector2 position, Sprite sprite);
    }

  /*   public class BoundBoxFactory : BoundBoxSpriteFactory
    {
        private static ItemFactory instance;

        public static ItemFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ItemFactory();
                }
                return instance;
            }
        }

        public override Sprite CreateBoundBox(Game1 game, Vector2 position, Sprite sprite)
        {

        }

    }
 */
}
