using Microsoft.Xna.Framework;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.CollisionDetection
{
    public class Grid
    {
        public static Cell[,] GetGrid { get; set; }

        static int height = 33;
        static int width = 33;

        private static Grid instance;

        public static Grid Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Grid();
                }
                return instance;
            }
        }


        public Grid()
        {
            SetupGrids();
        }

        public static List<Cell> getSurroundingCells(Entity entity)
        {
            List<Cell> surroundingCells = new List<Cell>();

            int startColunm = (int)Math.Floor((double)entity.Min.X / width);
            int startRow = (int)Math.Floor((double)entity.Min.Y / height);

            int endColunm = (int)Math.Floor((double)entity.Max.X / width);
            int endRow = (int)Math.Floor((double)entity.Max.Y / height);

            for (int i = startColunm; i <= endColunm; i++)
            {
                for (int j = startRow; j <= endRow; j++)
                {
                    surroundingCells.Add(GetGrid[i, j]);
                }
            }

            return surroundingCells;
        }


        public void AddEntity(Entity entity)
        {
            List<Cell> surroundingCells = getSurroundingCells(entity);

            foreach(Cell cell in surroundingCells)
            {
                if(!cell.CellEntities.Contains(entity))
                    cell.CellEntities.Add(entity);
            }

        }

        public void RemoveEntity(Entity entity)
        {
            List<Cell> surroundingCells = getSurroundingCells(entity);

            foreach (Cell cell in surroundingCells)
            {
                cell.CellEntities.Remove(entity);
            }
        }

        public List<Entity> getSurroundingEntity(Entity entity, List<Entity> collidables)
        {
            List<Entity> surroundingEntities = new List<Entity>();
            List<Cell> surroundingCells = getSurroundingCells(entity);

            foreach(Cell cell in surroundingCells)
            {
                foreach(Entity entity1 in cell.CellEntities)
                {

                    //
                    if (!surroundingEntities.Contains(entity1) && collidables.Contains(entity1))
                        surroundingEntities.Add(entity1);
                }
            }

            return surroundingEntities;
        }

        public void SetupGrids()
        {
            double y = 510;
            double x = 6350;

            int colunms = (int)Math.Ceiling(x / width);
            int rows = (int)Math.Ceiling(y / height);

            GetGrid = new Cell[colunms, rows];
            Debug.WriteLine("there are " + colunms + "colunms and " + rows + "rows");
            for (int i = 0; i < colunms; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    GetGrid[i, j] = new Cell(new Vector2(33 * i, 33 * j), new Vector2(33, 33));
                }
            }
        }
    }
}
