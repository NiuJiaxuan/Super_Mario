using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Block.State;
using Sprint0.CollisionDetection;
using Sprint0.Item;
using Sprint0.Mario;
using Sprint0.Sprites;
using Sprint0.Sprites.factory;
using Sprint0.State;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Block
{
    public class QuestionBlockEntity : BlockEntity
    {
        public ItemEntity item;

        public QuestionBlockEntity(Game1 game, Vector2 position, bool isVisible, BlockItemType blockItemType)
            : base(game, position)
        {
            Sprite = BlockFactory.CreateBlock(game, position, (int)eBlockType.QuestionBlock);
            if ((int)blockItemType != 6)
                item = new ItemEntity(game, position,false, blockItemType);
            BlockType = eBlockType.QuestionBlock;
            CurrentState = new QuestionBlockNormalState(this);
            CurrentState.Enter(null);
            IsVisible = isVisible;

        }

        public void marioCollsionDetection(MarioEntity mario, List<Entity> blockEntities)
        {
            List<Entity> entities = new List<Entity>();
            entities.Add(mario);
            Tuple<Collision.Touching, float, float, Entity> detected = collisionDetection.detectCollsion(entities);

            if (detected.Item1 == Collision.Touching.bottom)
            {
                Debug.WriteLine("touch bottom");
                ChangeToVisible();
                BumpTransition();
            }

        }

        public override void Update(GameTime gameTime, MarioEntity mario, List<Entity> enemyEntities, List<Entity> blockEntities)
        {
            marioCollsionDetection(mario, blockEntities);
            base.Update(gameTime, mario, enemyEntities, blockEntities);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            
            base.Draw(spriteBatch);
            
        }
    }
}
