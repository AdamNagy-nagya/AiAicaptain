using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldManager : IWorldManager
{
    public TileBase WaterTile;
    public TileBase LandTile;
    public TileBase BorderTile;
    public TileBase GoalTile;

    public Tilemap TileMap;

    public int MapNumber = 1;
    public bool RandomMap = false;
    public bool LoadMap = false;

    private IGameMap gameMap;

    private ISceneRouter sceneRouter;

    public IGameMap GetGameMap() => gameMap;

    public WorldManager(TileBase waterTile, TileBase landTile, TileBase borderTile, Tilemap tilemap,
                      int mapNumber)
    {
        WaterTile = waterTile;
        LandTile = landTile;
        BorderTile = borderTile;
        GoalTile = waterTile;
        TileMap = tilemap;
        MapNumber = mapNumber;
        MakeMap();
        sceneRouter = new SceneRouter();
    }

    public WorldManager(TileBase waterTile, TileBase landTile, TileBase borderTile, TileBase goalTile, Tilemap tilemap,
                    int mapNumber)
    {
        WaterTile = waterTile;
        LandTile = landTile;
        BorderTile = borderTile;
        GoalTile = goalTile;
        TileMap = tilemap;
        MapNumber = mapNumber;
        MakeMap();
        sceneRouter = new SceneRouter();
    }

    private void MakeMap()
    {

        if (MapNumber < 10 || MapNumber == 33)
        {
            if (MapNumber == 0)
            {
                gameMap = MapGenerator.GenerateRandomMap(MapNumber);
            }
            else
            {
                gameMap = MapGenerator.GenerateMap(MapNumber);
            }
        }
        else
        {
            gameMap = MapFileLoader.LoadMap(MapNumber);
        }

        foreach (ITile tile in gameMap.GetTileList())
        {
            switch (tile.TileType)
            {
                case TileType.WATER:
                    TileMap.SetTile(new Vector3Int(tile.X * 10, 0, tile.Y * 10), WaterTile);
                    break;
                case TileType.START:
                    TileMap.SetTile(new Vector3Int(tile.X * 10, 0, tile.Y * 10), WaterTile);
                    break;
                case TileType.LAND:
                    TileMap.SetTile(new Vector3Int(tile.X * 10, 0, tile.Y * 10), LandTile);
                    break;
                case TileType.BORDER:
                    TileMap.SetTile(new Vector3Int(tile.X * 10, 0, tile.Y * 10), BorderTile);
                    break;
                case TileType.GOAL:
                    TileMap.SetTile(new Vector3Int(tile.X * 10, 0, tile.Y * 10), GoalTile);
                    break;
            }
        }
    }

    public void gameEnded()
    {
        sceneRouter.backToMenu();
    }

}
