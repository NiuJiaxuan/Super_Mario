using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Sprint0.Interfaces
{
    public interface IEnemyState
    {
        IEnemyState PreviousState { get; }
        void Enter(IEnemyState PreviousState);
        void Exit();
        void Update(GameTime gameTime);
        void KillTransition();
        void NormalTransition();
        void ShellTransition();


    }
}
