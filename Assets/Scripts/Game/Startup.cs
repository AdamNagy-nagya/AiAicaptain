using Assets.Scripts.Player.FreePlay;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Startup : MonoBehaviour
{
    private int submarineInitX = 1;
    private int submarineInitY = 1;

    public GameObject SubmarinePrefab;


    public List<GameObject> WaterLandBorderGoalObjects;
    public List<RuleTile> WaterLandBorderGoalTiles;

    public Tilemap TileMap;

    public int MapNumber = 1;

    [Range(0f, 1.0f)]
    public int ControlType = 0;

    private ISubmarineTunels submarineTunel;



    // Start is called before the first frame update
    void Start()
    {
        int index = 0;
        foreach (GameObject gameObject in WaterLandBorderGoalObjects)
        {
            WaterLandBorderGoalTiles[index++].m_DefaultGameObject = gameObject;
        }

        IWorldManager worldManager = new WorldManager(waterTile: WaterLandBorderGoalTiles[0],
                                                    landTile: WaterLandBorderGoalTiles[1],
                                                    borderTile: WaterLandBorderGoalTiles[2],
                                                    goalTile: WaterLandBorderGoalTiles[3],
                                                    tilemap: TileMap, MapNumber
                                                    );

        Tuple<int, int> submarineStart = worldManager.GetGameMap().GetStartPosition();

        if (submarineStart != null)
        {
            submarineInitX = submarineStart.Item1;
            submarineInitY = submarineStart.Item2;
        }

        var submarineGameObject = Instantiate(SubmarinePrefab,
                                            new Vector3((submarineInitX * 10), -0.5f, (submarineInitY * 10)),
                                            Quaternion.identity);
        var behaviour = submarineGameObject.GetComponent<SubmarineBehaviour>();

        ISubmarine submarine = new Submarine(behaviour, worldManager);

        if (ControlType < 1)
        {
            new AIPlayerDiscovery().GetFirstFreePlayer().OnGameStart(new SubmarineTunnel(submarine));
        }
        else
        {
            new AIPlayerDiscovery().GetFirstFreePlayer().OnGameStart(new SubmarineTunnelWithContext(submarine));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
