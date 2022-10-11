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
    public class GoombaEntity : EnemyEntity
    {

        public GoombaEntity(Game1 game, Vector2 position)
            : base(game, position) 
        { 
            Sprite = EnemyFactory.CreateEnemy(game, position,(int)eEnemyType.Goomba);
            EnemyType = eEnemyType.Goomba;

        }

        public override void Update(GameTime gameTime,MarioEntity mario, List<Entity> blockEntities)
        {
            base.Update(gameTime,mario, blockEntities);

            Speed += Accelation * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
        }

    }
}
