using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TerrainGenerator spawn new Terrain from player position
//Code followed from Youtube Tutorial
public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private int maxTerrainCount;
    [SerializeField] private List<TerrainInf> terrainData = new List<TerrainInf>();
    [SerializeField] private Transform terrainHolder;
    private List<GameObject> currenTerrains = new List<GameObject>();
    [HideInInspector] public Vector3 currentPosition = new Vector3(0, 0, 0);
    [SerializeField] private int minDistanceFromPlayer;

    private void Start()
    {
        for(int i = 0; i<maxTerrainCount; i++)
        {
            SpawnTerrain(true, new Vector3(0, 0, 0));

        }
        maxTerrainCount = currenTerrains.Count;

    }

    public void SpawnTerrain( bool isStart, Vector3 playerPos)
    {
        if((currentPosition.x - playerPos.x < minDistanceFromPlayer) || (isStart))
        {
            int whichTerrain = Random.Range(0, terrainData.Count);
            int terrainInSuccession = Random.Range(1, terrainData[whichTerrain].maxInSuccession);
            for (int i = 0; i < terrainInSuccession; i++)
            {
                GameObject terrain = Instantiate(terrainData[whichTerrain].allTerrain[Random.Range(0, terrainData[whichTerrain].allTerrain.Count)], currentPosition, Quaternion.identity, terrainHolder);
                terrain.transform.SetParent(terrainHolder);
                currenTerrains.Add(terrain);
                if (!isStart)
                {
                    if (currenTerrains.Count > maxTerrainCount)
                    {
                        Destroy(currenTerrains[0]);
                        currenTerrains.RemoveAt(0);
                    }
                }

                currentPosition.x++;

            }
        }

    }
 

}

