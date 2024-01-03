using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;

    [SerializeField]
    [Range(1,1000)]
    int enemyCount;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemyCount; i++) {
            Instantiate(enemyPrefab, GetRandomPosition(), Quaternion.identity);
        }
    }

    private Vector3 GetRandomPosition() {
        var point = new Vector3(Random.Range(10f, 100f), 60f, Random.Range(10f, 100f));
        if (Physics.Raycast(point, Vector3.down, out RaycastHit hit, 61f)) {
            point = hit.point;
            return point;
        }
        return GetRandomPosition();
    }
}
