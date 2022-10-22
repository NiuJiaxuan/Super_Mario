using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.CollisionDetection
{
    public class Grid
    {
        Vector2 Min;
        Vector2 Max;
        Vector2 GridSize;
        Rectangle Rectangle { get; set; }

        public Grid(Vector2 gridSize, Vector2 position)
        {
            Min = position;
            Max = new Vector2(position.X + gridSize.X, position.Y + gridSize.Y);
            this.GridSize = gridSize;
            Rectangle = new Rectangle((int)position.X, (int)position.Y, (int)gridSize.X, (int)gridSize.Y);
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
