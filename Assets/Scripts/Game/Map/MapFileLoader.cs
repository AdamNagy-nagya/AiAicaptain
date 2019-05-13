using System;
using System.Collections.Generic;
using System.IO;

static class MapFileLoader
{
    public static IGameMap LoadMap(int levelId)
    {
        switch (levelId)
        {
            case 11:
                return generateMapFromString(loadFileString("BeginFirstMap"));
            case 12:
                return generateMapFromString(loadFileString("BeginTurnSimpleMap"));
            case 13:
                return generateMapFromString(loadFileString("BeginTurnAdvancedMap"));

            case 14:
                return generateMapFromString(loadFileString("SimpleTurnMap"));

            case 21:
                return generateMapFromString(loadFileString("ForFirstMap"));
            case 22:
                return generateMapFromString(loadFileString("ForTurnSimpleMap"));
            case 23:
                return generateMapFromString(loadFileString("ForTurnAdvancedMap"));

            case 31:
                return generateMapFromString(loadFileString("DoubleForMap"));
            case 32:
                return generateMapFromString(loadFileString("AdvancedDoubleForMap"));
            case 33:
                throw new Exception("MapFileLoader: map 33: This map generated, not loading from file!");
            case 41:
                return generateMapFromString(loadFileString("Map1"));
            case 42:
                return generateMapFromString(loadFileString("Map2"));
            case 43:
                return generateMapFromString(loadFileString("Map3"));
            case 44:
                return generateMapFromString(loadFileString("Map4"));
            case 45:
                return generateMapFromString(loadFileString("Map5"));
            case 46:
                return generateMapFromString(loadFileString("Map6"));
            case 47:
                return generateMapFromString(loadFileString("Map7"));
            case 48:
                return generateMapFromString(loadFileString("Map8"));
            case 49:
                return generateMapFromString(loadFileString("Map9"));
            case 50:
                return generateMapFromString(loadFileString("Map10"));
            case 51:
                return generateMapFromString(loadFileString("Map11"));
            case 52:
                return generateMapFromString(loadFileString("Map12"));
            case 53:
                return generateMapFromString(loadFileString("Map13"));
            case 54:
                return generateMapFromString(loadFileString("Map14"));


            default:
                throw new Exception("Unvalid map number added in setup!");
        }


    }

    private static string loadFileString(string fileName)
    {

        string path = "Assets/Maps/" + fileName + ".txt";

        StreamReader reader = new StreamReader(path);
        string returnString = reader.ReadToEnd();
        reader.Close();
        return returnString;
    }

    private static IGameMap generateMapFromString(string mapString)
    {
        string[] stringList = mapString.Split(';');

        int mapX = 1, mapY = 1, startX = 1, startY = 1;

        List<ITile> tileList = new List<ITile>();

        for (int i = 0; i < stringList.Length; i++)
        {
            if (i == 0)
            {
                mapX = Convert.ToInt32(stringList[i]);
            }
            else if (i == 1)
            {
                mapY = Convert.ToInt32(stringList[i]);
            }
            else
            {
                //TODO Refactor to one place
                TileType tileType;

                Tuple<int, int> tileCoords = calculateCoords(mapX, mapY, i - 2);
                switch (stringList[i])
                {

                    case "I":
                        tileType = TileType.BORDER;
                        break;
                    case "W":
                        tileType = TileType.WATER;
                        break;
                    case "L":
                        tileType = TileType.LAND;
                        break;
                    case "X":
                        tileType = TileType.GOAL;
                        break;
                    case "S":
                        tileType = TileType.START;
                        startX = tileCoords.Item1;
                        startY = tileCoords.Item2;
                        break;
                    default:
                        throw new Exception("MapFileLoader: LoadMap unwalid char in mapfile!");
                }
                tileList.Add(new Tile(tileCoords.Item1, tileCoords.Item2, tileType));
            }

        }

        return new GameMap(tileList, new Tuple<int, int>(startX, startY));
    }

    private static Tuple<int, int> calculateCoords(int mapX, int mapY, int listIndex)
    {
        int y = listIndex / mapX;
        int x = listIndex % mapX;

        return new Tuple<int, int>(x, y);
    }




}
