using SunshineConsole;
using OpenTK.Graphics;
using OpenTK.Input;
using System.Threading;


namespace RogueLike
{
    public class Program
    {




       private static ConsoleWindow gameWindow = new ConsoleWindow(32, 64, "The Adventures of Brandy Andy");
       private static Player player = new Player(gameWindow.Rows / 2, gameWindow.Cols / 2, '@' );
        


        static void Main(string[] args)
        {
            //Initialize screen
            
            gameWindow.Write(14, 27, "Gamer Time", Color4.LimeGreen);
            gameWindow.WindowUpdate();


            Thread.Sleep(2000);


            gameWindow.Write(player.playerXCoord, player.playerYCoord, player.playerIcon, Color4.White);
            gameWindow.Write(14, 27, "          ", Color4.Black);
            gameWindow.Write(27, 0, "-----------------------------------------------------------------", Color4.AliceBlue);
            



            //Game Loop
            while (!gameWindow.KeyIsDown(Key.Escape) && gameWindow.WindowUpdate())
            {
                //Initialize health and mana
                gameWindow.Write(29, 8, $"HEALTH: {player.currentHP}/{player.totalHP}", Color4.IndianRed);
                gameWindow.Write(29, 45, $"MANA: {player.currentMP}/{player.totalMP}", Color4.DeepSkyBlue);

                if (gameWindow.KeyPressed)
                {
                    Key key = gameWindow.GetKey();
                    CheckMovement(key);
                }

            }
        }



        public static void CheckMovement(Key key)
        {
            
            switch (key)
            {
                case Key.Left:
                    gameWindow.Write(player.playerXCoord, player.playerYCoord, ' ', Color4.Black);
                    player.playerYCoord -= 1;

                    //Ensures that the player doesn't move off the game window
                    if(player.playerYCoord < 0)
                    {
                        player.playerYCoord = 0;
                    }
                    gameWindow.Write(player.playerXCoord, player.playerYCoord, player.playerIcon, Color4.White);
                    break;

                case Key.Right:
                    gameWindow.Write(player.playerXCoord, player.playerYCoord, ' ', Color4.Black);
                    player.playerYCoord += 1;

                    //Ensures that the player doesn't move too far right off the screen
                    if (player.playerYCoord > 63) //Set to 63 Because the boundaries technically start at 0
                    {
                        player.playerYCoord = 63;
                    }
                    gameWindow.Write(player.playerXCoord, player.playerYCoord, player.playerIcon, Color4.White);
                    break;

                case Key.Up:
                    gameWindow.Write(player.playerXCoord, player.playerYCoord, ' ', Color4.Black);
                    player.playerXCoord -= 1;

                    //Ensures the player doesn't leave the top of the screen
                    if(player.playerXCoord < 0)
                    {
                        player.playerXCoord = 0;
                    }
                    gameWindow.Write(player.playerXCoord, player.playerYCoord, player.playerIcon, Color4.White);
                    break;

                case Key.Down:
                    gameWindow.Write(player.playerXCoord, player.playerYCoord, ' ', Color4.Black);
                    player.playerXCoord += 1;

                    //Ensures the player doesn't go below the menu screen
                    if(player.playerXCoord >= 27)
                    {
                        player.playerXCoord = 26;
                    }
                    gameWindow.Write(player.playerXCoord, player.playerYCoord, player.playerIcon, Color4.White);
                    break;

            }
        }
    }
}
