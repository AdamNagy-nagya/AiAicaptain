using System;
using System.Collections.Generic;

class GameMap : IGameMap
{
    private List<ITile> tileList;
    private Tuple<int, int> startPosition;

    public GameMap(List<ITile> tileList)
    {
        this.tileList = tileList;
    }

    public GameMap(List<ITile> tileList, Tuple<int, int> startPosition)
    {
        this.tileList = tileList;
        this.startPosition = startPosition;
    }

    public List<ITile> GetTileList() => tileList;

    public ITile GetTile(int x, int y)
    {
        return tileList.Find(tile => tile.X == x && tile.Y == y);
    }

    public Tuple<int, int> GetStartPosition() => startPosition;

    public ITile GetGoalTile()
    {
        return null;
    }
}