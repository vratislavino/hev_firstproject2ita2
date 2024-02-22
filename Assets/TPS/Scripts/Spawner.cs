using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] private float spawnInterval;
    private float spawnCooldown;

    [SerializeField] private float mapSize;
    [SerializeField] private List<BaseEnemy> enemyPrefabs;

    void Start()
    {
        spawnCooldown = spawnInterval;   
    }

    void Update()
    {
        if (spawnCooldown > 0)
        {
            spawnCooldown -= Time.deltaTime;
            if (spawnCooldown <= 0)
            {
                Spawn();
                spawnCooldown = spawnInterval;
            }
        }
    }

    private void Spawn()
    {
        var prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
        var position = GetPosition();
        Instantiate(prefab, position, Quaternion.identity);
    }

    private Vector3 GetPosition()
    {
        Vector3 pos = new Vector3(1, 1, 1);
        if (player.position.x > 0) pos.x *= -1;
        if (player.position.z > 0) pos.z *= -1;

        pos.x *= Random.Range(mapSize / 3, mapSize);
        pos.z *= Random.Range(mapSize / 3, mapSize);

        return pos;
    }
}
