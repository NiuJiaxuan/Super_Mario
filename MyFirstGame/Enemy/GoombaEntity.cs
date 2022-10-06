using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemy
{
    public class GoombaEntity : Entity
    {

        public virtual EnemyFactory GoombaFactory => game.GoombaFactory;

        public GoombaEntity(Game1 game, Vector2 position)
            : base(game, position)
        {
            Sprite = (Sprite)GoombaFactory.CreateGoomba(game, position);

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
