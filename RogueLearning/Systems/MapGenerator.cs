using RLNET;
using RogueSharp;
using System;
using System.Linq;

namespace RogueLearning
{
   public class MapGenerator
    {
        private readonly int _width;
        private readonly int _height;
        private readonly int _maxRooms;
        private readonly int _roomMaxSize;
        private readonly int _roomMinSize;

        private readonly DungeonMap _map;


        public MapGenerator(int width, int height, int maxRooms, int roomMaxSize, int roomMinSize )
        {
            _width = width;
            _height = height;
            _maxRooms = maxRooms;
            _roomMaxSize = roomMaxSize;
            _roomMinSize = roomMinSize;
            _map = new DungeonMap();
        }

        public DungeonMap CreateMap()
        {
            //the Initialize method esentially creates a grid of cells the size of the width and height passed in
            _map.Initialize(_width, _height);

            for (int i = 0; i < _maxRooms; i++)
            {
                //Determine the size and position of the room randomly.
                //When selecting the x and y position of the room, we subtract it from the _width and height of the room so the room doesnt extend pass the boundries of the console
                int roomWidth = Engine.Random.Next(_roomMinSize, _roomMaxSize);
                int roomHeight = Engine.Random.Next(_roomMinSize, _roomMaxSize);
                int roomXPosition = Engine.Random.Next(0, _width - roomWidth - 1);
                int roomYPosition = Engine.Random.Next(0, _height - roomHeight - 1);

                //All of the rooms will be represented by rectangles
                var newRoom = new Rectangle(roomXPosition, roomYPosition, roomWidth, roomHeight);

                //Check to see if the room rectabgle crosses another room
                bool newRoomIntersects = _map.Rooms.Any(room => newRoom.Intersects(room));

                //If it doesn;t intersect, add it to the list of rooms
                if (!newRoomIntersects)
                {
                    _map.Rooms.Add(newRoom);
                }
            }

            foreach(Rectangle room in _map.Rooms)
            {
                CreateRoom(room);
            }

            return _map;
        }

        private void CreateRoom(Rectangle room)
        {
            for (int x = room.Left +1; x< room.Right; x++)
            {
                for (int y =room.Top +1; y < room.Bottom; y++)
                {
                    _map.SetCellProperties(x, y, true, true, true);
                }
            }
        }
    }
}
