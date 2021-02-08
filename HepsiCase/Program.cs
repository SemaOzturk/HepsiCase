using System;
using System.Collections.Generic;
using System.Linq;

namespace HepsiCase
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var initialPositionText = Console.ReadLine().Split(" ");
            var roverPosition =
                new PositionalVector(new Point(
                        int.Parse(initialPositionText[0]),
                        int.Parse(initialPositionText[1])),
                    Enum.Parse<Direction>(initialPositionText[2]));
            var commands = Console.ReadLine();
            var fieldManager = new FieldManager(roverPosition, new Point(dimensions[0], dimensions[1]));

            foreach (var command in commands)
            {
                fieldManager.Move(command);
            }
            
            initialPositionText = Console.ReadLine().Split(" ");
            var roverPosition2 =
                new PositionalVector(new Point(
                        int.Parse(initialPositionText[0]),
                        int.Parse(initialPositionText[1])),
                    Enum.Parse<Direction>(initialPositionText[2]));
            commands = Console.ReadLine();
            fieldManager = new FieldManager(roverPosition2, new Point(dimensions[0], dimensions[1]));

            foreach (var command in commands)
            {
                fieldManager.Move(command);
            }
            Console.WriteLine(roverPosition);
            Console.WriteLine(roverPosition2);
        }
    }

    public class Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void IncreaseX()
        {
            X++;
        }

        public void IncreaseY()
        {
            Y++;
        }

        public void DecreaseX()
        {
            X--;
        }

        public void DecreaseY()
        {
            Y--;
        }

        public void CheckXBoundary(int x)
        {
            if (X > x)
            {
                X = x;
            }

            if (X < 0)
            {
                X = 0;
            }
        }

        public void CheckYBoundary(int y)
        {
            if (Y > y)
            {
                Y = y;
            }

            if (Y < 0)
            {
                Y = 0;
            }
        }

        public override string ToString()
        {
            return $"{X} {Y}";
        }
    }

    public class PositionalVector
    {
        public Point Point { get; }
        public Direction Direction { get; private set; }

        public PositionalVector(Point point, Direction direction)
        {
            Point = point;
            Direction = direction;
        }

        public void SetDirection(Direction direction)
        {
            Direction = direction;
        }

        public void Move()
        {
            switch (Direction)
            {
                case Direction.N:
                    Point.IncreaseY();
                    break;
                case Direction.E:
                    Point.IncreaseX();
                    break;
                case Direction.S:
                    Point.DecreaseY();
                    break;
                case Direction.W:
                    Point.DecreaseX();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override string ToString()
        {
            return $"{Point} {Direction}";
        }
    }

    public class FieldManager
    {
        private readonly PositionalVector _roverPosition;
        private readonly Point _field;
        private readonly DirectionCommandState _directionCommandState = new DirectionCommandState();

        public FieldManager(PositionalVector roverPosition, Point field)
        {
            _roverPosition = roverPosition;
            _field = field;
        }


        public void Move(char moveCommand)
        {
            var command = Enum.Parse<Command>(moveCommand.ToString().ToUpper());
            switch (command)
            {
                case Command.R:
                case Command.L:
                    var newDirection = _directionCommandState.Rotate(_roverPosition.Direction, command);
                    _roverPosition.SetDirection(newDirection);
                    goto default;
                case Command.M:
                    _roverPosition.Move();
                    goto default;
                default:
                    CheckBoundary();
                    break;
            }
        }

        private void CheckBoundary()
        {
            _roverPosition.Point.CheckXBoundary(_field.X);
            _roverPosition.Point.CheckYBoundary(_field.Y);
        }
    }

    public class DirectionCommandState
    {
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

    public enum Command
    {
        L,
        M,
        R
    }

    public enum Direction
    {
        N = 0,
        E = 1,
        S = 2,
        W = 3
    }
}