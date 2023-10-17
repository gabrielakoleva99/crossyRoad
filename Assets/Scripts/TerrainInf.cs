using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Terrain Inf", menuName = "Terrain Inf")]

//TerrainInf stores the tarain data such as grass, road and water

public class TerrainInf : ScriptableObject
{
    public List<GameObject> allTerrain;
    public int maxInSuccession;
}
