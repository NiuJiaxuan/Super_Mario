using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Item.State
{
    public interface IItemState
    {
        IItemState PreviousState { get; }
        void Enter(IItemState previousState);
        void Exit();
        void Update(GameTime gameTime);
        void NormalTransition();
        void BumpTransition();

    }
}
