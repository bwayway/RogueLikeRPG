using RLNET;
using RogueSharp;

namespace RogueLearning.Interfaces
{
    public class Actor : IActor, IDrawable
    {
        //IActor properties
        public string Name { get; set; }
        public int Awareness { get; set; }

        //IDrawable Properties
        public RLColor Color { get; set; }
        public char Symbol { get; set; }
        public int x { get; set; }
        public int y { get; set; }

       public void Draw(RLConsole console, IMap map)
        {
            if (!map.GetCell( x, y).IsExplored)
            {
                return;
            }
            if(map.IsInFov(x, y))
            {
                console.Set(x, y, Color, Colors.FloorBackgroundFov, Symbol);
            }
            else
            {
                console.Set(x, y, Colors.Floor, Colors.FloorBackground, '.');
            }
        }
    }
}

