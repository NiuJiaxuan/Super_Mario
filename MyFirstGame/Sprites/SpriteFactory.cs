using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Sprites;
using Sprint0.interfaces;

namespace Sprint0.Sprites
{
    //Abstract sprite factory class
    // to use, create a new facotry class inherient this class an add implement in create method
    abstract class MarioFactory 
    {
        protected Random random;

        protected MarioFactory()
        {
            random = new Random(DateTime.Now.Millisecond);
        }
        public abstract ISprite IdleMario(Game1 game, Vector2 postion);
        public abstract ISprite RunningMario(Game1 game, Vector2 position);
        public abstract ISprite JumpingMario(Game1 game, Vector2 position);
        public abstract ISprite FallingMario(Game1 game, Vector2 position);
        public abstract ISprite CrouchingMario(Game1 game, Vector2 position);

    }

    abstract class BlockFactory
    {
        protected Random random;

        protected BlockFactory()
        {
            random = new Random(DateTime.Now.Millisecond);
        }
        public abstract ISprite CreateBlock(Game1 game, Vector2 postion);
    }


    // player one factory or mario factory
    // generate a new mario sprite
    class NormalMarioFactory : MarioFactory
    {
        private static MarioFactory instance;

        public static MarioFactory Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new NormalMarioFactory();
                }
                return instance;
            }
        }

        public override ISprite IdleMario(Game1 game, Vector2 pos)
        {
            return new NormalMarioStandingSprite(game,pos );
        }

        public override ISprite RunningMario(Game1 game, Vector2 position)
        {
            return new NormalMarioStandingSprite(game, position);//need changes
        }

        public override ISprite JumpingMario(Game1 game, Vector2 position)
        {
            return new NormalMarioStandingSprite(game, position);//need changes
        }
        public override ISprite FallingMario(Game1 game, Vector2 position)
        {
            return new NormalMarioStandingSprite(game, position);//need changes
        }
        public override ISprite CrouchingMario(Game1 game, Vector2 position)
        {
            return new NormalMarioStandingSprite(game, position);//need changes
        }
    }



    // player one factory or mario factory
    // generate a new mario sprite
    class FireMarioFactory : MarioFactory
    {
        private static MarioFactory instance;

        public static MarioFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FireMarioFactory();
                }
                return instance;
            }
        }

        public override ISprite IdleMario(Game1 game, Vector2 pos)
        {
            return new FireMarioStandingSprite(game, pos);
        }

        public override ISprite RunningMario(Game1 game, Vector2 position)
        {
            return new FireMarioStandingSprite(game, position);//need changes
        }

        public override ISprite JumpingMario(Game1 game, Vector2 position)
        {
            return new FireMarioStandingSprite(game, position);//need changes
        }
        public override ISprite FallingMario(Game1 game, Vector2 position)
        {
            return new FireMarioStandingSprite(game, position);//need changes
        }
        public override ISprite CrouchingMario(Game1 game, Vector2 position)
        {
            return new FireMarioStandingSprite(game, position);//need changes
        }
    }



    // player one factory or mario factory
    // generate a new mario sprite
    class SuperMarioFactory : MarioFactory
    {
        private static MarioFactory instance;

        public static MarioFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SuperMarioFactory();
                }
                return instance;
            }
        }

        public override ISprite IdleMario(Game1 game, Vector2 pos)
        {
            return new SuperMarioStandingSprite(game, pos);
        }

        public override ISprite RunningMario(Game1 game, Vector2 position)
        {
            return new SuperMarioStandingSprite(game, position);//need changes
        }

        public override ISprite JumpingMario(Game1 game, Vector2 position)
        {
            return new SuperMarioStandingSprite(game, position);//need changes
        }
        public override ISprite FallingMario(Game1 game, Vector2 position)
        {
            return new SuperMarioStandingSprite(game, position);//need changes
        }
        public override ISprite CrouchingMario(Game1 game, Vector2 position)
        {
            return new SuperMarioStandingSprite(game, position);//need changes
        }
    }

    abstract class DMarioFactory
    {
        protected Random random;

        protected DMarioFactory()
        {
            random = new Random(DateTime.Now.Millisecond);
        }
        public abstract ISprite DeadMario(Game1 game, Vector2 postion);

    }

    class DeadMarioFactory : DMarioFactory
    {
        private static DeadMarioFactory instance;

        public static DeadMarioFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DeadMarioFactory();
                }
                return instance;
            }
        }

        public override ISprite DeadMario(Game1 game, Vector2 pos)
        {
            return new SuperMarioStandingSprite(game, pos);
        }
    }

    class QuestionBlockFactory : BlockFactory
    {
        private static BlockFactory instance;

        public static BlockFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new QuestionBlockFactory();
                }
                return instance;
            }
        }

        public override ISprite CreateBlock(Game1 game, Vector2 pos)
        {
            return new QuestionBlockSprite(game, pos);
        }
    }
    class FloorBlockFactory : BlockFactory
    {
        private static BlockFactory instance;

        public static BlockFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FloorBlockFactory();
                }
                return instance;
            }
        }

        public override ISprite CreateBlock(Game1 game, Vector2 pos)
        {
            return new FloorBlockSprite(game, pos);
        }
    }

    class BrickBlockFactory : BlockFactory
    {
        private static BlockFactory instance;

        public static BlockFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BrickBlockFactory();
                }
                return instance;
            }
        }

        public override ISprite CreateBlock(Game1 game, Vector2 pos)
        {
            return new BrickBlockSprite(game, pos);
        }
    }
    class UsedBlockFactory : BlockFactory
    {
        private static BlockFactory instance;

        public static BlockFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UsedBlockFactory();
                }
                return instance;
            }
        }

        public override ISprite CreateBlock(Game1 game, Vector2 pos)
        {
            return new UsedBlockSprite(game, pos);
        }
    }
    class StairBlockFactory : BlockFactory
    {
        private static BlockFactory instance;

        public static BlockFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StairBlockFactory();
                }
                return instance;
            }
        }

        public override ISprite CreateBlock(Game1 game, Vector2 pos)
        {
            return new StairBlockSprite(game, pos);
        }
    }

}
