using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Mario.MarioPowerState
{
    public interface IMarioPowerState
    {

        IMarioPowerState PreviousState { get; }

        void Enter(IMarioPowerState state);
        void Exit();

        void FireTransion();
        void NormalTransion();
        void SuperTransion();
        void DeadTransion();

        void Update(GameTime gameTime);
    }
}
