using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwawner : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public GameObject enemyPrefab, enemies;

    public float enemyBurstCount = 3, spawntime = 1;

    Transform location;
    float updatetime;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
            spawnPoints.Add(child);
        //Time.timeScale = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > updatetime)
        {
            updatetime = Time.time + spawntime;
            spawnEnemy();
        }
    }

    public void spawnEnemy()
    {
        if (enemies.transform.childCount < enemyBurstCount)
        {
            location = spawnPoints[Random.Range(0, transform.childCount)];
            var enemyInstance = Instantiate(enemyPrefab, location);
            enemyInstance.transform.SetParent(enemies.transform);
            //enemyInstance.transform.LookAt(Vector3.zero);
            enemyInstance.transform.LookAt(transform.forward);
        }
    }
}
