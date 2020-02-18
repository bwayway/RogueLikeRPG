using RLNET;
using System;
using RogueLearning.Core;

namespace RogueLearning
{
    public class Engine
    {
        // The total screen height and width
        private static readonly int _screenWidth = 100;
        private static readonly int _screenHeight = 70;
        private static RLRootConsole _rootConsole;

        //The Map console
        private static readonly int _mapWidth = 80;
        private static readonly int _mapHeight = 48;
        private static RLConsole _mapConsole;

        //Message console to display events and information
        private static readonly int _messageWidth = 80;
        private static readonly int _messageHeight = 11;
        private static RLConsole _messageConsole;

        //Stat Console displays player and monster stats
        private static readonly int _statWidth = 20;
        private static readonly int _statHeight = 70;
        private static RLConsole _statConsole;

        //Inventory console shows players equipment, abilities, items
        private static readonly int _inventoryWidth = 80;
        private static readonly int _inventoryHeight =11;
        private static RLConsole _inventoryConsole;

        //The map
        private static DungeonMap DungeonMap { get;  set; }

        //Actors
        public static Player Player { get; private set; }





        static void Main(string[] args)
        {
            _rootConsole = new RLRootConsole("ascii_8x8.png", _screenWidth, _screenHeight, 8, 8, 1f, "RLLearning");

            //Create console windows
            _mapConsole = new RLConsole(_mapWidth, _mapHeight);
            _messageConsole = new RLConsole(_messageWidth, _messageHeight);
            _statConsole = new RLConsole(_statWidth, _statHeight);
            _inventoryConsole = new RLConsole(_inventoryWidth, _inventoryHeight);

            //Set Console Windows
            _messageConsole.SetBackColor(0, 0, _messageWidth, _messageHeight, Palette.ComplimentDarkest);
            _messageConsole.Print(1, 1, "Messages", RLColor.White);

            _statConsole.SetBackColor(0, 0, _statWidth, _statHeight, Palette.SecondaryDarkest);
            _statConsole.Print(1, 1, "Stats", RLColor.White);

            _inventoryConsole.SetBackColor(0, 0, _inventoryWidth, _inventoryHeight, Palette.AlternateDarkest);
            _inventoryConsole.Print(1, 1, "Inventory", RLColor.White);

            //Create Player
            Player = new Player();

            MapGenerator mapGenerator = new MapGenerator(_mapWidth, _mapHeight);
            DungeonMap = mapGenerator.CreateMap();

            DungeonMap.UpdatePlayerFieldOfView();

            _rootConsole.Render += OnRootConsoleRender;
            _rootConsole.Update += OnRootConsoleUpdate;

            _rootConsole.Run();
        }





        private static void OnRootConsoleRender(object sender, UpdateEventArgs e)
        {
            DungeonMap.Draw(_mapConsole);
            Player.Draw(_mapConsole, DungeonMap);

            /*Blitting - adding two consoles (bitmaps) on top of each other.
             * Takes the source console, the starting position for X and Y, the dimensions of the source console, then takes the root console and maps 
             * the source console based on dimensions passed in
            */
            RLConsole.Blit(_mapConsole, 0, 0, _mapWidth, _mapHeight, _rootConsole, 0, _inventoryHeight);
            RLConsole.Blit(_statConsole, 0, 0, _statWidth, _statHeight, _rootConsole, _mapWidth, 0);
            RLConsole.Blit(_messageConsole, 0, 0, _messageWidth, _messageHeight, _rootConsole, 0, _screenHeight - _messageHeight);
            RLConsole.Blit(_inventoryConsole, 0, 0, _inventoryWidth, _inventoryHeight, _rootConsole, 0, 0);


            
            _rootConsole.Draw();

            


        }




        private static void OnRootConsoleUpdate(object sender, UpdateEventArgs e)
        {
           

            

        }
    }
}
