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
    public abstract class MarioSpriteFactory 
    {

        public enum eMarioType
        {
            DeadMario = 0,

            NormalIdleMario = 1,
            NormalWalkMario = 2,
            NormalJumpMario = 3,
            NormalCrouchMario = 4,

            FireIdleMario = 11,
            FireWalkMario = 12,
            FireJumpMario = 13,
            FireCrouchMario = 14,

            SuperIdleMario = 21,
            SuperWalkMario = 22,
            SuperJumpMario = 23,
            SuperCrouchMario = 24,
        }
        protected MarioSpriteFactory()
        {
        }
        public abstract ISprite CreateMario(Game1 game, Vector2 pos,  int type);

    }


    // player one factory or mario factory
    // generate a new mario sprite
    public class MarioFactory : MarioSpriteFactory
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

        public override Sprite CreateMario(Game1 game, Vector2 pos, int type)
        {
            Sprite sprite = null;
            Debug.WriteLine(type);
            Debug.WriteLine((eMarioType)type);
            switch ((eMarioType)type)
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
