using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameMode : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyManager.instance.GetEnemies().Count == 0 && WaveManager.instance.GetWaveSpawner().Count == 0)
        { 
            SceneManager.LoadScene("WinScreen");
        }
    }
}
