using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using Sprint0.Sprites;

namespace Sprint0.interfaces
{
    public interface IState
    {


        void Update(GameTime gameTime );

        void Draw(SpriteBatch batch);
    }
}
