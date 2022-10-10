using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Block.State;
using Sprint0.Mario;
using Sprint0.Mario.MarioMotionState;
using Sprint0.Mario.MarioPowerState;
using Sprint0.Sprites;
using Sprint0.Sprites.factory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Sprint0.State
{
    public class BlockEntity : Entity
    {
        private Sprite smallBlock1;
        private Sprite smallBlock2;
        private Sprite smallBlock3;
        private Sprite smallBlock4;
        public IBlockState CurrentState { get; set; }
        public eBlockType BlockType { get; set; }
        public MarioEntity Mario { get; set; }

        public virtual BlockFactory BlockFactory => game.BlockFactory;

        public bool IsVisible = true;
        public bool breakBlockVisible = true;
        public Sprite SmallBlock1
        {
            get { return smallBlock1; }
            set { smallBlock1 = value; }
        }
        public Sprite SmallBlock2
        {
            get { return smallBlock2; }
            set { smallBlock2 = value; }
        }
        public Sprite SmallBlock3
        {
            get { return smallBlock3; }
            set { smallBlock3 = value; }
        }
        public Sprite SmallBlock4
        {
            get { return smallBlock4; }
            set { smallBlock4 = value; }
        }
        public enum eBlockType
        {
            QuestionBlock = 1,
            BrickBlock = 2,
            FloorBlock = 3,
            StairBlock = 4,
            UsedBlock = 5,
            SmallBrickBlock = 6,
        }

        public enum BlockItemType
        {
            Coin,
            FireFlower,
            OneUpMushroom,
            Star,
            SuperMushroom,
            None
        }


        public BlockEntity(Game1 game, Vector2 position) : base(game, position)
        {
        }

        public override void Update(GameTime gameTime, List<Entity> entities)
        {
            Speed += Accelation * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            CurrentState?.Update(gameTime);            
            
            base.Update(gameTime,entities);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            if (breakBlockVisible)
            {
                base.Draw(spriteBatch);
            }
            
            
            SmallBlock1?.Draw(spriteBatch);
            SmallBlock2?.Draw(spriteBatch);
            SmallBlock3?.Draw(spriteBatch);
            SmallBlock4?.Draw(spriteBatch);
            
            
        }


        public void BumpTransition()
        {
            CurrentState?.BumpTransition();
        }


    }
}
