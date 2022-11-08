using Microsoft.Xna.Framework;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Interfaces
{
    public interface ITimer
    {

        public void Update(GameTime gameTime);
        public Entity GetEntity { get; set; }

    }
}
