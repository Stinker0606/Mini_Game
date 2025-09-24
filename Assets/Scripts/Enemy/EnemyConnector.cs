using UnityEngine;

public class EnemyConnector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnemyManager.instance.AddEnemy(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        EnemyManager.instance.RemoveEnemy(this);
    }
}
