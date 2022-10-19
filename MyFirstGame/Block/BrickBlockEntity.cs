using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Block.State;
using Sprint0.CollisionDetection;
using Sprint0.Item;
using Sprint0.Mario;
using Sprint0.Mario.MarioPowerState;
using Sprint0.Sprites;
using Sprint0.State;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint0.State.BlockEntity;

namespace Sprint0.Block
{
    public class BrickBlockEntity : BlockEntity
    {


        public BrickBlockEntity(Game1 game, Vector2 position, bool isVisible, Entity item)
            : base(game, position)
        {
            Sprite = BlockFactory.CreateBlock(game,position, (int)eBlockType.BrickBlock);
            BlockType = eBlockType.BrickBlock;
            CurrentState = new BrickBlockNormalState(this);
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
                BumpOrBreakTransition();
            }

        }


        public override void Update(GameTime gameTime, MarioEntity mario, List<Entity> enemyEntities, List<Entity> blockEntities)
        {
            Mario = mario;
            marioCollsionDetection(mario, blockEntities);
            base.Update(gameTime, mario,enemyEntities,blockEntities);

        }
        public override void Draw(SpriteBatch spriteBatch)
        {        
            base.Draw(spriteBatch);
            
        }

    }
}
