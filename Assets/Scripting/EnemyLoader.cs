using UnityEngine;
using UnityEngine.Rendering;

public class EnemyLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject ennemyPrefab;
    private GameObject spawnZone;
    [Range(0, 6)]
    public float spawnZoneScale;
    [Range(3,10)]
    public float spawnTimer;
    public Material spawnMaterial;
    void Start()
    {
        InvokeRepeating("SpawnEnnemy", 2.0f, spawnTimer);
    }

    // Update is called once per frame
    void SpawnEnnemy()
    {
        Vector3 enemyOffset = new Vector3(Random.Range(-spawnZoneScale/2.0f, spawnZoneScale / 2.0f), 0 , Random.Range(-spawnZoneScale / 2.0f, spawnZoneScale / 2.0f));
        Instantiate(ennemyPrefab, transform.position + enemyOffset, Quaternion.identity);
    }
}
