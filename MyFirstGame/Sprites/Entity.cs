using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.interfaces;
using Sprint0.CollisionDetection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Mario;
using System.Threading;
using Microsoft.VisualBasic.FileIO;
using Sprint0.Interfaces;

namespace Sprint0.Sprites
{
    public abstract class Entity 
    {
        private Sprite _sprite;
        public Game1 game;
        public bool showBoundBox;
        public bool IsVisible = true;

        public bool onGround { get; set; }

        public Sprite Sprite
        {
            get { return _sprite; }
            set { _sprite = value; }
        }

        public List<Entity> Entities
        {
            get; set;
        }

        public Point Min
        {
            get { return new Point((int)Position.X, (int)(Position.Y- Sprite.FrameSize.Y)); }
        }

        public Point Max
        {
            get { return new Point((int)(Position.X + Sprite.FrameSize.X), (int)Position.Y); }
        }

        public List<Cell> SurroundingGrids
        {
            get { return Grid.getSurroundingCells(this); }
        }

        public virtual Rectangle GetRectangle
        {
            get { return new Rectangle((int)Position.X, (int)(Position.Y- Sprite.FrameSize.Y), (int)Sprite.FrameSize.X, (int)Sprite.FrameSize.Y); }
        }


        public virtual SpriteEffects Orientation
        {
            get { return Sprite.Orientation; }
            set { Sprite.Orientation = value; }
        }

        public Vector2 Speed
        {
            get;set;
        }

        public Vector2 Accelation
        {
            get;set;
        }

        public Vector2 Position
        {
            get { return Sprite.Position; }
            set { Sprite.Position = value; }
        }

        public Entity(Game1 game, Vector2 position)
        {
            this.game = game;
            showBoundBox = false;      
            onGround = true;
        }


        public virtual void CollisionResponse(Entity entity, Vector2 position, CollisionDetector.Touching touching) { }



        public virtual void Update (GameTime gameTime, List<Entity> entities)
        {


            this.Entities = entities;
            Sprite.Update(gameTime);

            // ---------------------------------- gravity---------------------------------

            if (EntityStorage.Instance.MovableEntities.Contains(this))
            {
                if (!onGround)
                {
                    Accelation = new Vector2(0, 500);
                }
                else
                {
                    Speed = new Vector2(Speed.X, 0);
                    Accelation = Vector2.Zero;
                }
            }


            Speed += Accelation * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(Speed != Vector2.Zero)
            {
                Grid.Instance.RemoveEntity(this);
            }
            Position += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (Speed != Vector2.Zero)
                Grid.Instance.AddEntity(this);

            if ((Position.X < 5 || Position.Y > 480) && !(this is MarioEntity) && !(this is IStaticEntity))
            {
                EntityStorage.Instance.completeRemove(this);
            }
        }



        public Color BoxColor { get; set; }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

            if (showBoundBox)
            {
                RectangleSprite.DrawRectangle(spriteBatch, GetRectangle, Color.Green, 2);
                if (this is IMovableEntity)
                {
                    foreach (Cell grid in SurroundingGrids)
                    {
                        grid.Draw(spriteBatch);
                    }
                }
            }

            if(IsVisible)
            Sprite.Draw(spriteBatch);
        }

//----------------------------------------Show Bound Box Command-----------------------------------

        public virtual void ShowBoundBox()
        {
            showBoundBox = !showBoundBox;
        }
    }
}
