using RLNET;
using RogueSharp;
using RogueLearning.Interfaces;

namespace RogueLearning.Core
{
    public class Player : Actor
    {
        public Player()
        {
            Awareness = 15;
            Name = "Rogue";
            Color = RLColor.White;
            Symbol = '@';
            x = 10;
            y = 10;
        }
    }
}
