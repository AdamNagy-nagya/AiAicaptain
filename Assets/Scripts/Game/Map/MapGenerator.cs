using System;
using System.Collections.Generic;

static class MapGenerator
{
    public static IGameMap GenerateMap(int level)
    {
        switch (level)
        {
            case 1:
                return createTestMap();
            case 2:
                return createFirstMap();
            case 3:
                return createSecondMap();
            case 33:
                return createWhileRandomLenghtMap();

            default:
                throw new Exception("MapGenerator invalid mapnumber!");
        }
    }

    public static IGameMap GenerateRandomMap(int size)
    {
        int mapSize = size;

        List<ITile> tileList = new List<ITile>();

        Random rnd = new Random();
        int startX = rnd.Next(1, mapSize - 2);
        int startY = rnd.Next(1, mapSize - 2);

        for (int i = 0; i < (mapSize * mapSize); i++)
        {
            int y = i / mapSize;
            int x = i % mapSize;

            int land = rnd.Next(1, 10);

            TileType tileType;
            if (x == startX && y == startY)
            {
                tileType = TileType.START;
            }
            else if (y == 0 || y == mapSize - 1 || x == 0 || x == mapSize - 1)
            {
                tileType = TileType.BORDER;
            }
            else if (land == 1)
            {
                tileType = TileType.LAND;
            }
            else
            {
                tileType = TileType.WATER;
            }
            tileList.Add(new Tile(x, y, tileType));
        }

        return new GameMap(tileList, new Tuple<int, int>(startX, startY));

    }

    private static IGameMap createEmptyMap()
    {
        int mapSize = 10;

        List<ITile> tileList = new List<ITile>();

        for (int i = 0; i < (mapSize * mapSize); i++)
        {
            int y = i / mapSize;
            int x = i % mapSize;
            TileType tileType;


            if (y == 0 || y == mapSize - 1 || x == 0 || x == mapSize - 1)
            {
                tileType = TileType.BORDER;
            }
            else
            {
                tileType = TileType.WATER;
            }
            tileList.Add(new Tile(x, y, tileType));
        }

        return new GameMap(tileList);
    }


    private static IGameMap createFirstMap()
    {
        int mapSize = 5;

        List<ITile> tileList = new List<ITile>();

        for (int i = 0; i < (mapSize * mapSize); i++)
        {
            int y = i / mapSize;
            int x = i % mapSize;
            TileType tileType;
            if (x == 1 && y == 1)
            {
                tileType = TileType.START;
            }
            else if (x == 3 && y == 3)
            {
                tileType = TileType.GOAL;
            }
            else if (y == 0 || y == mapSize - 1 || x == 0 || x == mapSize - 1)
            {
                tileType = TileType.BORDER;
            }
            else
            {
                tileType = TileType.WATER;
            }
            tileList.Add(new Tile(x, y, tileType));
        }

        return new GameMap(tileList);
    }




    private static IGameMap createSecondMap()
    {

        int mapSize = 15;

        List<ITile> tileList = new List<ITile>();

        for (int i = 0; i < (mapSize * mapSize); i++)
        {
            int y = i / mapSize;
            int x = i % mapSize;
            TileType tileType;
            if (y == 0 || y == mapSize - 1 || x == 0 || x == mapSize - 1)
            {
                tileType = TileType.BORDER;
            }
            else if (y == mapSize / 2 || x == mapSize / 2)
            {
                tileType = TileType.LAND;
            }
            else
            {
                tileType = TileType.WATER;
            }
            tileList.Add(new Tile(x, y, tileType));
        }

        return new GameMap(tileList);
    }


    private static IGameMap createTestMap()
    {

        int mapSize = 10;

        List<ITile> tileList = new List<ITile>();

        for (int i = 0; i < (mapSize * mapSize); i++)
        {
            int y = i / mapSize;
            int x = i % mapSize;

            TileType tileType;
            if (x == 0 && y == 0)
            {

                tileType = TileType.WATER;
            }
            else
            if (y == 0 || y == mapSize - 1 || x == 0 || x == mapSize - 1)
            {
                tileType = TileType.BORDER;
            }
            else if (y == x)
            {
                tileType = TileType.LAND;
            }
            else
            {
                tileType = TileType.WATER;
            }
            tileList.Add(new Tile(x, y, tileType));
        }

        return new GameMap(tileList);
    }


    private static IGameMap createWhileRandomLenghtMap()
    {

        int mapWidth = 3;
        int mapLenght = new Random().Next(10,20);

        List<ITile> tileList = new List<ITile>();

        for (int i = 0; i < (mapWidth * mapLenght); i++)
        {
            int y = i / mapWidth;
            int x = i % mapWidth;

            TileType tileType;

            if (x == 1 && y == 1)
            {
                tileType = TileType.START;
            }
            else if (y == 0 || y == mapLenght - 1 || x == 0 || x == mapWidth - 1)
            {
                tileType = TileType.BORDER;
            }
            else if (y == mapLenght-2 && x == mapWidth - 2)
            {
                tileType = TileType.GOAL;
            }
            else
            {
                tileType = TileType.WATER;
            }
            tileList.Add(new Tile(x, y, tileType));
        }

        return new GameMap(tileList);
    }



}


