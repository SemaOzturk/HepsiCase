using System.Collections.Generic;

namespace HepsiCase
{
    public class DirectionCommandState
    {
        public enum Command
        {
            L,
            M,
            R
        }
        private readonly Dictionary<(Direction, Command), Direction> States = new Dictionary<(Direction, Command), Direction>()
        {
            {(Direction.N, Command.L), Direction.W},
            {(Direction.N, Command.R), Direction.E},
            {(Direction.S, Command.L), Direction.E},
            {(Direction.S, Command.R), Direction.W},
            {(Direction.E, Command.L), Direction.N},
            {(Direction.E, Command.R), Direction.S},
            {(Direction.W, Command.L), Direction.S},
            {(Direction.W, Command.R), Direction.N},
        };

        public Direction Rotate(Direction direction, Command command)
        {
            return States[(direction, command)];
        }
    }
   
}