namespace HepsiCase
{
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
}