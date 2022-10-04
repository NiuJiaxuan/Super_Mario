using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Sprites;
using Sprint0.interfaces;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites
{
    //Abstract sprite factory class
    // to use, create a new facotry class inherient this class an add implement in create method
    public abstract class MarioSpriteFactory 
    {
        public enum eMarioType
        {
            DeadMario = 0x0000,

            NormalIdleMario = 0x0001,
            NormalWalkMario = 0x0002,
            NormalJumpMario = 0x0003,
            NormalCrouchMario = 0x0004,

            FireIdleMario = 0x0010,
            FireWalkMario = 0x0020,
            FireJumpMario = 0x0030,
            FireCrouchMario = 0x0040,

            SuperIdleMario = 0x0100,
            SuperWalkMario = 0x0200,
            SuperJumpMario = 0x0300,
            SuperCrouchMario = 0x0400,
        }
        protected MarioSpriteFactory()
        {
        }
        public abstract ISprite CreateMario(Game1 game, Vector2 pos,  eMarioType type);

    }


    // player one factory or mario factory
    // generate a new mario sprite
    class MarioFactory : MarioSpriteFactory
    {
        private static MarioFactory instance;

        public static MarioFactory Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new MarioFactory();
                }
                return instance;
            }
        }

        public override ISprite CreateMario(Game1 game, Vector2 pos, eMarioType type)
        {
            Sprite sprite = null;
            switch (type)
            {
                case eMarioType.DeadMario:
                    sprite = new DeadMarioSprite(game, pos);
                    break;
                case eMarioType.NormalIdleMario:
                    sprite = new NormalMarioIdleSprite(game, pos);
                    break;
                case eMarioType.NormalJumpMario:
                    sprite = new NormalMarioJumpSprite(game, pos);
                    break;
                case eMarioType.NormalWalkMario:
                    sprite = new NormalMarioWalkSprite(game, pos);
                    break;
                case eMarioType.NormalCrouchMario:
                    sprite = new NormalMarioCrouchSprite(game, pos);
                    break;

                case eMarioType.FireIdleMario:
                    sprite = new FireMarioIdleSprite(game, pos);
                    break;
                case eMarioType.FireJumpMario:
                    sprite = new FireMarioJumpSprite(game, pos);
                    break;
                case eMarioType.FireWalkMario:
                    sprite = new FireMarioWalkSprite(game, pos);
                    break;
                case eMarioType.FireCrouchMario:
                    sprite = new FireMarioCrouchSprite(game, pos);
                    break;

                case eMarioType.SuperIdleMario:
                    sprite = new SuperMarioIdleSprite(game, pos);
                    break;
                case eMarioType.SuperJumpMario:
                    sprite = new SuperMarioJumpSprite(game, pos);
                    break;
                case eMarioType.SuperWalkMario:
                    sprite = new SuperMarioWalkSprite(game, pos);
                    break;
                case eMarioType.SuperCrouchMario:
                    sprite = new SuperMarioCrouchSprite(game, pos);
                    break;
            }
            return sprite;
        }
    }

}
