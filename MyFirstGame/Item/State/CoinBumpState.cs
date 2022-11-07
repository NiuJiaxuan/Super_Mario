using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Sprint0.Block.State;
using Sprint0.ScoreSystem;
using Sprint0.State;

namespace Sprint0.Item.State
{
    class CoinBumpState : ItemStates
    {
        Vector2 Origion;

        public CoinBumpState(ItemEntity item)
            : base(item)
        {
        }
        public override void Enter(IItemState previousState)
        {
            SoundStorage.Instance.PlayCoin();
            ScoreSystemManager.Instance.Coin();
            CurrentState = this;
            this.previousState = previousState;
            Origion = Item.Position;

            Item.Speed = new Vector2(0, -60);
        }

        public override void Exit()
        {
            Item.Speed = new Vector2(0, 0);
            EntityStorage.Instance.movableRemove(Item);
        }


        public override void Update(GameTime gameTime)
        {
            if (Math.Abs(Item.Position.Y - Origion.Y) >= 30)
                Exit();
        }
    }
}
