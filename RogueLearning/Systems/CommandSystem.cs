
using RogueLearning.Core;

namespace RogueLearning.Systems
{
    public class CommandSystem
    {
        //Return true if player is able to move
        //false when player can't move/collides with wall/actor
        public bool MovePlayer(Direction direction)
        {
            int x = Engine.Player.x;
            int y = Engine.Player.y;

            switch (direction)
            {
                case Direction.Up:
                    {
                        y = Engine.Player.y - 1;
                        break;
                    }
                case Direction.Down:
                    {
                        y = Engine.Player.y + 1;
                        break;
                    }
                case Direction.Left:
                    {
                        x = Engine.Player.x - 1;
                        break;
                    }
                case Direction.Right:
                    {
                        x = Engine.Player.x + 1;
                        break;
                    }
                default:
                    {
                        return false;
                    }
            }

            if(Engine.DungeonMap.SetActorPosition(Engine.Player,x ,y))
            {
                return true;
            }
            return false;

        }

    }
}
