using SunshineConsole;
using OpenTK.Graphics;
using OpenTK.Input;

namespace RogueLike
{
    public class Player
    {
        public int playerXCoord { get; set; }
        public int playerYCoord { get; set; }
        public char playerIcon { get; set; }
        public int totalHP { get; set; }
        public int currentHP { get; set; }
        public int totalMP { get; set; }
        public int currentMP { get; set;}


        public Player(int xCord, int yCord, char icon)
        {
            playerXCoord = xCord;
            playerYCoord = yCord;
            playerIcon = icon;
            totalHP = 10;
            currentHP = totalHP;
            totalMP = 5;
            currentMP = totalMP;
        }

    }
}
