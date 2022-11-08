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
    public class Cell
    {
        Vector2 Min;
        Vector2 Max;
        Vector2 CellSize;

        public Rectangle Rectangle { get; set; }
        public Vector2 Position { get; set; }

        public List<Entity> CellEntities { get; set; }

        public Cell(Vector2 position,Vector2 gridSize)
        {
            Min = position;
            this.Position = position;
            Max = new Vector2(position.X + gridSize.X, position.Y + gridSize.Y);
            this.CellSize = gridSize;
            Rectangle = new Rectangle((int)position.X, (int)position.Y, (int)gridSize.X, (int)gridSize.Y);
            CellEntities = new List<Entity>();
        }

        public void RecordSurroundingEntities(List<Entity> entities)
        {

        }

        public void UpdateSurroundingEntities()
        {

        }

        //public static List<Cell> getSurroundingGrids(Entity entity)
        //{
        //    List<Cell> surroundingGrids = new List<Cell>();
        //    foreach (Cell grid in EntityStorage.Instance.AllGrids.GetGrid)
        //    {
        //        if (grid.Rectangle.Intersects(entity.GetRectangle))
        //        {
        //            surroundingGrids.Add(grid);
        //        }
        //    }

        //    return surroundingGrids;
        //}

        public List<Cell> Contains(Cell[,] grids, Entity entity)
        {
            List<Cell> containsEntity = new List<Cell>();

            foreach(Cell grid in grids)
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
