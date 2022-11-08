using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Block.State.GameState;
using Sprint0.Item;
using Sprint0.Mario.MarioMotionState;
using Sprint0.ScoreSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Mario.MarioPowerState
{
    public class DeadState : MarioPowerState
    {
        Vector2 anchor;
        long timeCounter = 0;
        public DeadState(MarioEntity mario)
            : base(mario)
        {
        }

        public override void Enter(IMarioPowerState powerState)
        {
            if (!LifeSystem.Instance.isNoLife)
                SoundStorage.Instance.PlayDie();
            EntityStorage.Instance.movableRemove(Mario);
            SoundStorage.Instance.PauseBGM();
            LifeSystem.Instance.LoseOneLife();
            CurrentState = this;
            this.previousState = powerState;


            Mario.Accelation = Vector2.Zero;
            Mario.Speed = Vector2.Zero;


            anchor.X += Mario.Sprite.FrameSize.X;

            anchor = Mario.Position;
            Mario.onGround = true;
            //Mario.Speed = new Vector2(0, -200);


            int type = Mario.generateType(CurrentMotionState, CurrentState);
            Mario.Sprite = Mario.MarioFactory.CreateMario(Mario.game, Mario.Position, type);
            Mario.marioType = type;
            
        }

        public override void Update(GameTime gameTime)
        {
            timeCounter +=gameTime.ElapsedGameTime.Ticks;

            if (timeCounter > 30000000)
            {
                Mario.respawn();
            }
        }
        public override void NormalTransion()
        {
            CurrentState.Exit();
            CurrentState = new NormalState(Mario);
            CurrentState.Enter(this);
        }
        public override void FireTransion()
        {
            CurrentState.Exit();
            CurrentState = new FireState(Mario);
            CurrentState.Enter(this);
        }
        public override void SuperTransion()
        {
            CurrentState.Exit();
            CurrentState = new SuperState(Mario);
            CurrentState.Enter(this);
        }

        public override void Exit()
        {
            EntityStorage.Instance.movableAdd(Mario);
            base.Exit();
        }


    }
}
