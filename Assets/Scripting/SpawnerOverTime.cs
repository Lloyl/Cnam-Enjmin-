using System.Collections;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    GameObject spawner;
    [SerializeField]
    GameObject target;
    [SerializeField]
    GameObject enemy;

    private Coroutine spawnCoroutine;
    void Start()
    {
        StartCoroutine(CreateSpawnerCoroutine());
    }

    private IEnumerator CreateSpawnerCoroutine()
    {
        while (true)
        {
            CreateSpawner();
            yield return new WaitForSeconds(10);
        }
        //CreateSpawner();
        //yield return new WaitForEndOfFrame() ;
        //yield return new WaitForSeconds(10) ;
        //yield return new WaitUntil(() => newSpawnRequest) ;
        //newSpawnRequest = false;
    }
    // Update is called once per frame
    void CreateSpawner()
    {
        var spawnerInstance = Instantiate(spawner, transform);
        var enemySpawner = spawnerInstance.GetComponent<EnemyLoader>();
        //enemySpawner.SetennemyPrefab(PlayerController.transform);
    }

    public void StopCoroutine()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }
    }
}

