using Microsoft.Xna.Framework;
using Sprint0.CollisionDetection;
using Sprint0.Sprites;
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
        void Fire();
        void Normal();
        void Super();
        void TakeDamage();

        void CollisionResponse(Entity entity, Vector2 position, CollisionDetector.Touching touching);

    }
}
