using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.CollisionDetection
{
    public class Grid
    {
        Vector2 Min;
        Vector2 Max;
        Vector2 GridSize;
        public Rectangle Rectangle { get; set; }
        public Vector2 Position { get; set; }

        public Grid(Vector2 position,Vector2 gridSize)
        {
            Min = position;
            this.Position = position;
            Max = new Vector2(position.X + gridSize.X, position.Y + gridSize.Y);
            this.GridSize = gridSize;
            Rectangle = new Rectangle((int)position.X, (int)position.Y, (int)gridSize.X, (int)gridSize.Y);
        }

        public static List<Grid> getSurroundingGrids(Entity entity)
        {
            List<Grid> surroundingGrids = new List<Grid>();
            foreach (Grid grid in EntityStorage.Instance.AllGrids)
            {
                if (grid.Rectangle.Intersects(entity.GetRectangle))
                {
                    surroundingGrids.Add(grid);
                }
            }

            return surroundingGrids;
        }

        public List<Grid> Contains(Grid[,] grids, Entity entity)
        {
            List<Grid> containsEntity = new List<Grid>();

            foreach(Grid grid in grids)
            {
                if (entity.GetRectangle.Intersects(grid.Rectangle))
                {
                    containsEntity.Add(grid);
                }
            }

            return containsEntity;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            RectangleSprite.DrawRectangle(spriteBatch, Rectangle, Color.Wheat, 1);
        }

    }
}
