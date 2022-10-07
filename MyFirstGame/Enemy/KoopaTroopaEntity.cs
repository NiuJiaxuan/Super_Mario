using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemy
{
    public class KoopaTroopaEntity : Entity
    {
        public virtual EnemyFactory KoopaTroopaFactory => game.KoopaTroopaFactory;

        public KoopaTroopaEntity(Game1 game, Vector2 position)
            : base(game, position)
        {
            Sprite = (Sprite)KoopaTroopaFactory.CreateKoopaTroopa(game, position);

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Speed += Accelation * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
        }
    }
}
