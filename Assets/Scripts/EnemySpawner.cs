using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject meteorPrefab;
    float enemySpawnRate = 1.5f;
    float meteorSpawnRate = 5f;
    float minY = 1f;
    float maxY = 4f;
    float nextEnemySpawn = 1.5f;
    float nextMeteorSpawn = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextEnemySpawn)
        {
            SpawnEnemy();
            nextEnemySpawn = Time.time + enemySpawnRate;
        }

        if (Time.time >= nextMeteorSpawn)
        {
            SpawnMeteor();
            nextMeteorSpawn = Time.time + meteorSpawnRate;
        }
    }

    void SpawnEnemy()
    {
        bool spawnFromLeft = Random.value > 0.5f;
        float spawnX = spawnFromLeft ? -3f : 3f;
        float spawnY = Random.Range(minY, maxY);

        GameObject enemy = Instantiate(enemyPrefab, new Vector3(spawnX, spawnY, 0f), Quaternion.Euler(0f, 0f, 0f));
        Enemy enemyScript = enemy.GetComponent<Enemy>();

        float speed = Random.Range(1.5f, 3f);
        enemyScript.moveSpeed = spawnFromLeft ? speed : -speed;
    }

    void SpawnMeteor()
    {
        float spawnX = Random.Range(-2f, 2f);
        float spawnY = -6f;

        Instantiate(meteorPrefab, new Vector3(spawnX,spawnY, 0f), Quaternion.identity);
    }
}
