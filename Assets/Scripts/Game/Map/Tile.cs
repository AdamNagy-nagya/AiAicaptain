using System.Collections.Generic;

class Tile : ITile
{
    public int X { get; }
    public int Y { get; }
    public TileType TileType { get; }

    private List<IBuisnessObject> objects;

    public Tile(int x, int y, TileType tileType)
    {
        X = x;
        Y = y;
        TileType = tileType;
        objects = new List<IBuisnessObject>();
    }

    public bool isStepable()
    {
        return (TileType == TileType.WATER || TileType == TileType.GOAL) && objects.Count == 0;
    }

    public void leaveTile(IBuisnessObject buisnessObject)
    {
        objects.Remove(buisnessObject);
    }

    public void enterTile(IBuisnessObject buisnessObject)
    {
        objects.Add(buisnessObject);
        if (this.TileType == TileType.GOAL) {
            buisnessObject.notifyEnteredGoalTile();
        }
    }
}

public enum TileType
{
    WATER,
    LAND,
    BORDER,
    GOAL,
    START,
}