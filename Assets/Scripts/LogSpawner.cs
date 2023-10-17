using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script spawns logs at current spawning position
public class LogSpawner : MonoBehaviour
{
    [SerializeField] private GameObject logPrefab;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private float minSpawnInterval;
    [SerializeField] private float maxSpawnInterval;
    [SerializeField] private bool shouldFlipX;

    private void Start()
    {
        StartCoroutine(SpawnLogs());
    }

    //spawns logs in the interval minSPawnInterval and maxSpawnInterval
    private IEnumerator SpawnLogs()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));
            Vector3 spawnPos = spawnPosition.position;
            Quaternion rotation = Quaternion.identity;
            if (shouldFlipX)
            {
                rotation = Quaternion.Euler(0, 180, 0);
            }
            Instantiate(logPrefab, spawnPos, rotation);
        }
    }
}
