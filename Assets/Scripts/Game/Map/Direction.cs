public enum Direction
{
    EAST,
    WEST,
    NORTH,
    SOUTH,
}

public static class DirectionConverter
{

    public static Direction TurnLeft(Direction actualDirection)
    {
        switch (actualDirection)
        {
            case Direction.EAST:
                return Direction.SOUTH;
            case Direction.WEST:
                return Direction.NORTH;
            case Direction.NORTH:
                return Direction.EAST;
            case Direction.SOUTH:
                return Direction.WEST;
            default:
                throw new System.Exception("Invalid direction in DirectionConverter");
        }
    }

    public static Direction TurnRight(Direction actualDirection)
    {
        switch (actualDirection)
        {
            case Direction.EAST:
                return Direction.NORTH;
            case Direction.WEST:
                return Direction.SOUTH;
            case Direction.NORTH:
                return Direction.WEST;
            case Direction.SOUTH:
                return Direction.EAST;
            default:
                throw new System.Exception("Invalid direction in DirectionConverter");
        }
    }
}
