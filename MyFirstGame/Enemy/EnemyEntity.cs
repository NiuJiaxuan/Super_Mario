using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Mario;
using Sprint0.Sprites;
using Sprint0.Sprites.factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemy
{
    public class EnemyEntity : Entity
    {
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

        public override void Update(GameTime gameTime, MarioEntity mario, List<Entity> enemyEntity, List<Entity> blockEntities)
        {
            base.Update(gameTime,mario,enemyEntity, blockEntities);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
