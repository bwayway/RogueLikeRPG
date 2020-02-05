using RLNET;
using RogueSharp;

namespace RogueLearning
{
    public class DungeonMap : Map
    {
        public void Draw(RLConsole mapConsole)
        {
            mapConsole.Clear();
            foreach( Cell cell in GetAllCells())
            {
                SetConsoleSymbolForCell(mapConsole, cell);
            }
        }



        private void SetConsoleSymbolForCell(RLConsole console, Cell cell)
        {
            //The Cell has not been explored yet, do not draw to console
            if (!cell.IsExplored)
            {
                return;
            }

            //When a cell is in the FOV, it will be drawn with lighter colors
            if( IsInFov( cell.X, cell.Y))
            {
                // '.' for walkable cell, '#' for walls
                if (cell.IsWalkable)
                {
                    console.Set(cell.X, cell.Y, Colors.FloorFov, Colors.FloorBackgroundFov, '.');
                }
                else
                {
                    console.Set(cell.X, cell.Y, Colors.WallFov, Colors.WallBackgroundFov, '#');
                }

            }
            //When a cell is not in the FOV, draw it darker
            else
            {
                if (cell.IsWalkable)
                {
                    console.Set(cell.X, cell.Y, Colors.Floor, Colors.FloorBackground, '.');
                }
                else
                {
                    console.Set(cell.X, cell.Y, Colors.Wall, Colors.WallBackground, '#');
                }
            }
        }
    }
}
