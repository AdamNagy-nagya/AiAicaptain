using System.Collections.Generic;

public interface IGameMap
{
    ITile GetTile(int x, int y);

    List<ITile> GetTileList();

    System.Tuple<int, int> GetStartPosition();

    ITile GetGoalTile();

}