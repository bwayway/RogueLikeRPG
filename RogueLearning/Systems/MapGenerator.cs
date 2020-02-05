using RLNET;
using RogueSharp;
using System;

namespace RogueLearning
{
   public class MapGenerator
    {
        private readonly int _width;
        private readonly int _height;

        private readonly DungeonMap _map;


        public MapGenerator(int width, int height)
        {
            _width = width;
            _height = height;
            _map = new DungeonMap();
        }

        public DungeonMap CreateMap()
        {
            //Initialize every cell in the map
            //Set walkable, transparancy, and explored to true
            //the Initialize method esentially creates a grid of cells the size of the width and height passed in
            _map.Initialize(_width, _height);
            foreach(Cell cell in _map.GetAllCells())
            {
                _map.SetCellProperties(cell.X, cell.Y, true, true, true);
            }

            //Set the first and last ROWS in the map to not be transparent or walkable
            //Sets the borders for the room
            foreach(Cell cell in _map.GetCellsInRows(0, _height - 1))
            {
                _map.SetCellProperties(cell.X, cell.Y, false, false, true);
            }

            //Set the first and last COLUMNS in the mape to not be transparent tor walkable
            //Sets the borders for the room
            foreach (Cell cell in _map.GetCellsInColumns(0, _width - 1))
            {
                _map.SetCellProperties(cell.X, cell.Y, false, false, true);
            }

            return _map;
        }

    }
}
