using UnityEngine;

public class WaveSpawnerSimple : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] spawnPoints;
    public float startTime;
    public float endTime;
    public float spawnRate;
    public GameObject player;

    void Start()
    {
        WaveManager.instance.AddWaveSpawner(this);
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
        // 1. Wähle einen zufälligen Spawnpunkt aus dem Array aus
        int randomIndex = Random.Range(0, spawnPoints.Length);
        GameObject randomSpawnPoint = spawnPoints[randomIndex];

        // 2. Erstelle den Gegner an der Position des zufällig gewählten Spawnpunkts
        GameObject spawnedObject = Instantiate(enemyPrefab, randomSpawnPoint.transform.position, Quaternion.identity);

        // 3. Gib dem Gegner das Ziel (den Spieler)
        EnemyMovement movementComponent = spawnedObject.GetComponent<EnemyMovement>();
        if (movementComponent)
        {
            movementComponent.SetTarget(player);
        }
    }
    void CancelSpawn()
    {
        // Cancel the repeated invocation of the "Spawn" method
        CancelInvoke("Spawn");
        WaveManager.instance.RemoveWaveSpawner(this);

        // Additional cleanup or logic if needed
        Debug.Log("Spawning cancelled.");
    }
}