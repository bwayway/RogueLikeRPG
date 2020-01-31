using RLNET;
using System;

namespace RogueLearning
{
    public class Engine
    {
        private const int screenWidth = 80;
        private const int screenHeight = 24;
        private static int playerX;
        private static int playerY;

        private static RLRootConsole _rootConsole;




        static void Main(string[] args)
        {
            _rootConsole = new RLRootConsole("ascii_8x8.png", screenWidth, screenHeight, 8, 8, 2f, "RLLearning");
            _rootConsole.OnLoad += RootConsole_OnLoad;
            _rootConsole.Render += RootConsole_Render;
            _rootConsole.Update += RootConsole_Update;

            _rootConsole.Run();
        }




        private static void RootConsole_OnLoad(object sender, EventArgs e)
        {
            playerX = screenWidth / 2;
            playerY = screenHeight / 2;
        }




        private static void RootConsole_Render(object sender, UpdateEventArgs e)
        {

            _rootConsole.Clear();
            _rootConsole.SetChar(playerX, playerY, '@');

            _rootConsole.Draw();
        }




        private static void RootConsole_Update(object sender, UpdateEventArgs e)
        {
            RLKeyPress key = _rootConsole.Keyboard.GetKeyPress();

            if (key != null)
            {
                switch (key.Key)
                {
                    case RLKey.Left:
                        playerX -= 1;
                        break;

                    case RLKey.Right:
                        playerX += 1;
                        break;

                    case RLKey.Up:
                        playerY -= 1;
                        break;

                    case RLKey.Down:
                        playerY += 1;
                        break;

                    case RLKey.Escape:
                        _rootConsole.Close();
                        break;
                }
            }

            if(playerX < 0)
            {
                playerX = 0;
            }

            if(playerX > screenWidth - 1)
            {
                playerX = screenWidth -1;
            }

            if(playerY < 0)
            {
                playerY = 0;
            }

            if(playerY > screenHeight - 1)
            {
                playerY = screenHeight - 1;
            }


        }
    }
}
