using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    List<SpawnData> spawnData;

    private float speedMult = 1;

    void Start()
    {
        // InvokeRepeating("SpawnRandomObject", 0, 0.5f);
        Cholesterol.Instance.CholesterolChanged += OnCholesterolChanged;
        StartCoroutine(GenerateObjects());
    }

    private void OnCholesterolChanged(int score) {
        speedMult = Mathf.Pow(1.2f, (score / 30));
    }

    IEnumerator GenerateObjects() {

        while(true) {
            yield return new WaitForSeconds(Random.Range(0.2f, 0.6f));
            SpawnRandomObject();
        }

    }

    void Update()
    {
        
    }

    void SpawnObject(Rigidbody go) {

        var g = Instantiate(go, GetRandomPosition(), Quaternion.identity, transform);
        g.velocity = Vector3.down * 7 * speedMult;
        g.AddTorque(Vector3.up * 100);

        Destroy(g.gameObject, 5f);
    }

    private Vector3 GetRandomPosition() {
        return new Vector3(
            Random.Range(-3f, 3f),
            transform.position.y,
            transform.position.z
            );
    }

    Rigidbody GetRandomObject() {
        float rnd = Random.Range(0f, 1f);
        float sum = 0;

        for(int i = 0; i < spawnData.Count; i++) {
            sum += spawnData[i].Probability;
            if(rnd <= sum) {
                return spawnData[i].Prefab;
            }
        }

        return spawnData[1].Prefab;
    }

    void SpawnRandomObject() {
        SpawnObject(GetRandomObject());
    }
}

[System.Serializable]
public class SpawnData
{
    public Rigidbody Prefab;
    public float Probability;
}