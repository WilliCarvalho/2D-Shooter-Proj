using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Vector2 minSpawnPosition, maxSpawnPosition;
    [SerializeField] GameObject enemyPrefab;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            float xPosition = Random.Range(minSpawnPosition.x, maxSpawnPosition.x);
            float yposition = Random.Range(minSpawnPosition.y, maxSpawnPosition.y);
            Instantiate(enemyPrefab, new Vector2(xPosition, yposition), 
                Quaternion.identity);
        }
    }
}
