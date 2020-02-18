using RogueSharp;
using RLNET;

namespace RogueLearning.Interfaces
{
    public interface IDrawable
    {
        RLColor Color { get; set; }
        char Symbol { get; set; }
        int x { get; set; }
        int y { get; set; }

        void Draw(RLConsole console, IMap map);
    }
}
