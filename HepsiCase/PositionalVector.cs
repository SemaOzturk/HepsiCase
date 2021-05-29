using System;

namespace HepsiCase
{

    public enum Direction
    {
        N = 0,
        E = 1,
        S = 2,
        W = 3
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
}