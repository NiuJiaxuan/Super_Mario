using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Sprites;
using Sprint0.interfaces;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace Sprint0.Sprites
{
    //Abstract sprite factory class
    // to use, create a new facotry class inherient this class an add implement in create method
    public abstract class BlockSpriteFactory
    {

        public enum eBlockType
        {
            QuestionBlock = 1,
            BrickBlock = 2,
            FloorBlock = 3,
            StairBlock = 4,
            UsedBlock = 5,
            SmallBrickBlock = 6,
        }
        protected BlockSpriteFactory()
        {
        }
        public abstract ISprite CreateBlock(Game1 game, Vector2 pos, int type);

    }


    // player one factory or mario factory
    // generate a new mario sprite
    public class BlockFactory : BlockSpriteFactory
    {
        private static BlockFactory instance;

        public static BlockFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BlockFactory();
                }
                return instance;
            }
        }

        public override Sprite CreateBlock(Game1 game, Vector2 pos, int type)
        {
            Sprite sprite = null;
            Debug.WriteLine(type);
            Debug.WriteLine((eBlockType)type);
            switch ((eBlockType)type)
            {
                case eBlockType.QuestionBlock:
                    sprite = new QuestionBlockSprite(game, pos);
                    break;
                case eBlockType.BrickBlock:
                    sprite = new BrickBlockSprite(game, pos);
                    break;
                case eBlockType.FloorBlock:
                    sprite = new FloorBlockSprite(game, pos);
                    break;
                case eBlockType.SmallBrickBlock:
                    sprite = new SmallBrickBlockSprite(game, pos);
                    break;
                case eBlockType.StairBlock:
                    sprite = new StairBlockSprite(game, pos);
                    break;
                case eBlockType.UsedBlock:
                    sprite = new UsedBlockSprite(game, pos);
                    break;
            }
            return sprite;
        }
    }

}
