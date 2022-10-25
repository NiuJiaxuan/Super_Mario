using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Mario;
using Sprint0.Sprites;
using Sprint0.Sprites.factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.CollisionDetection;


namespace Sprint0.Enemy
{
    public class EnemyEntity : Entity//, IMovableEntity
    {
        public IEnemyState currentState { get; set; }

        public virtual EnemyFactory EnemyFactory => game.EnemyFactory;
        public eEnemyType EnemyType { get; set; }


        public EnemyEntity(Game1 game, Vector2 position) : base(game, position)
        {
        }

        public enum eEnemyType
        {
            Goomba = 1,
            KoopaTroopa = 2,
        }
        //public override void CollisionResponse(Entity entity, Vector2 position, CollisionDetector.Touching touching)
        //{
        //    EntityStorage.Instance.EntityList.Remove(this);
        //}

        public override void Update(GameTime gameTime, List<Entity> blockEntities)
        {
            base.Update(gameTime, blockEntities);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public void KillTransition()
        {
            currentState?.KillTransition();
        }
        public void ShellTransition()
        {
            currentState?.ShellTransition();
        }
    }
}
