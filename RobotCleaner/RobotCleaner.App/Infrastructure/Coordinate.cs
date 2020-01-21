namespace RobotCleaner.App.Infrastructure
{
    public struct Coordinate
    {
        private const int MAX_X_COORDINATE = 100_000;
        private const int MIN_X_COORDINATE = -100_000;
        private const int MAX_Y_COORDINATE = 100_000;
        private const int MIN_Y_COORDINATE = -100_000;
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; private set; }
        public int Y { get; private set; }


        public void MoveStepToEast()
        {
            if (X < MAX_X_COORDINATE)
                X++;
        }
        public void MoveStepToWest()
        {
            if (X > MIN_X_COORDINATE)
                X--;

        }
        public void MoveStepToNorth()
        {
            if (Y < MAX_Y_COORDINATE)
                Y++;
        }
        public void MoveStepToSouth()
        {
            if (Y > MIN_Y_COORDINATE)
                Y--;
        }

    }


}