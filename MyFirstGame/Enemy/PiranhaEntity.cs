using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Sprites.factory;
using Sprint0.Mario;
using Sprint0.CollisionDetection;
using Sprint0.Enemy.EnemyState;
using System.Diagnostics;
using Sprint0.Mario.MarioPowerState;
using Sprint0.State;
using Sprint0.Item;
using Sprint0.Block;

namespace Sprint0.Enemy
{
    public class PiranhaEntity : EnemyEntity
    {
        public PiranhaEntity(Game1 game, Vector2 position)
            : base(game, position)
        {
            //currentState = new IdleState(this);
            Sprite = EnemyFactory.CreateEnemy(game, position, (int)eEnemyType.Piranha);
            EnemyType = eEnemyType.Piranha;
            currentState = new PiranhaNormalState(this);
            currentState.Enter(null);
        }

        public override void CollisionResponse(Entity entity, Vector2 position, CollisionDetector.Touching touching)
        {
        }
        public override void Update(GameTime gameTime, List<Entity> blockEntities)
        {
            //EntityStorage.Instance.ColliableEntites.Remove(this);
            //EntityStorage.Instance.completeRemove(this);
            base.Update(gameTime, blockEntities);
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
        }
    }
}
