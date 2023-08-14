//using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Vector2 minSpawnArea, maxSpawnArea;
    [SerializeField] private GameObject enemyPrefab;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Vector2 spawnPosition = new Vector2(
               UnityEngine.Random.Range(minSpawnArea.x, maxSpawnArea.x),
               UnityEngine.Random.Range(minSpawnArea.y, maxSpawnArea.y));
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }


}
