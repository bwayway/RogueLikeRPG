using RLNET;
using RogueSharp;
using RogueLearning.Core;
using System.Collections.Generic;

namespace RogueLearning
{
    public class DungeonMap : Map
    {

        public List<Rectangle> Rooms;

        public DungeonMap()
        {
            Rooms = new List<Rectangle>();
        }


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


        public void UpdatePlayerFieldOfView()
        {
            Player player = Engine.Player;

            //Computes the players field of view based on position and awareness value
            ComputeFov(player.x, player.y, player.Awareness, true);

            //Mark all cells in the field of view as having been explored
            foreach(Cell cell in GetAllCells())
            {
                if(IsInFov (cell.X, cell.Y))
                {
                    SetCellProperties(cell.X, cell.Y, cell.IsTransparent, cell.IsWalkable, true);
                }
            }
        }




        public bool SetActorPosition( Actor actor, int x, int y)
        {
            //Check to see if the cell the actor will be moving to is walkable
            if(GetCell(x, y).IsWalkable)
            {
                //The cell the actor was previously on is now walkable
                SetIsWalkable(actor.x, actor.y, true);

                //Update actor's position
                actor.x = x;
                actor.y = y;
                //The new cell the actor is now on is not walkable. This makes sure actors don't pile on top of each other on the same cell
                SetIsWalkable(actor.x, actor.y, false);

                //Update FOV if the actor is the player
                if (actor is Player)
                {
                    UpdatePlayerFieldOfView();
                }
                return true;
            }
            return false;
        }

        public void SetIsWalkable (int x, int y, bool isWalkable)
        {
            Cell cell = GetCell(x, y);
            SetCellProperties(cell.X, cell.Y, cell.IsTransparent, isWalkable, cell.IsExplored);
        }
    }
}
