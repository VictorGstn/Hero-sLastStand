using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject EnemySpawned;
    [SerializeField] float SpawnerTime;
    [SerializeField] float SpawnStart;
    [SerializeField] Vector2 SpawnPosition;
    [SerializeField] GameObject Player;
    float timer;
    public float timeValue = 0;

    [SerializeField] Transform topRightCorner;
    [SerializeField] Transform bottomLeftCorner;

    void Update()
    {
        timeValue += Time.deltaTime;
        timer -= Time.deltaTime;
        if(timer < 0f && SpawnStart<=timeValue)
        {
            SpawnEnemy();
            timer = SpawnerTime;
        }
    }
    
    void SpawnEnemy()
    {
        Vector2 spawnPosition = RandomPosition();

        spawnPosition.x += Player.transform.position.x;
        spawnPosition.y += Player.transform.position.y;

        if (spawnPosition.x > topRightCorner.position.x)
        {
            spawnPosition.x = bottomLeftCorner.position.x;
        }
        else if (spawnPosition.x < bottomLeftCorner.position.x)
        {
            spawnPosition.x = topRightCorner.position.x;
        }
        if (spawnPosition.y > topRightCorner.position.y)
        {
            spawnPosition.y = bottomLeftCorner.position.y;
        }
        else if (spawnPosition.y < bottomLeftCorner.position.y)
        {
            spawnPosition.y = topRightCorner.position.y; 
        }
        GameObject enemySpawned = Instantiate(EnemySpawned);
        enemySpawned.transform.position = spawnPosition;
    }

    private Vector2 RandomPosition()
    {
        Vector2 position = new Vector2();
        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;

        if (UnityEngine.Random.value > 0.5f)
        {
            position.x = UnityEngine.Random.Range(-SpawnPosition.x, SpawnPosition.x);
            position.y = SpawnPosition.y * f;
        }
        else
        {
            position.x = UnityEngine.Random.Range(-SpawnPosition.y, SpawnPosition.y);
            position.y = SpawnPosition.x * f;
        }

        return position;
    }
}
