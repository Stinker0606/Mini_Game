using UnityEngine;

public class WaveSpawnerSimple : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject spawnPoint;
    public float startTime;
    public float endTime;
    public float spawnRate;

    void Start()
    {
        // Invoke the "Spawn" method repeatedly starting after "startTime" seconds,
        // with "spawnRate" seconds between each invocation.
        // --> don't put it in update!
        InvokeRepeating("Spawn", startTime, spawnRate);
        // Invoke the "CancelSpawn" method once after "endTime" seconds.
        Invoke("CancelSpawn", endTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()
    {
        Debug.Log("Spawning started.");
        Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);

    }
    void CancelSpawn()
    {
        // Cancel the repeated invocation of the "Spawn" method
        CancelInvoke("Spawn");

        // Additional cleanup or logic if needed
        Debug.Log("Spawning cancelled.");
    }
}