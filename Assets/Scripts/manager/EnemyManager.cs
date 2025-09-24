using System;
using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static EnemyManager instance { get; private set; }
    private List<EnemyConnector> enemies = new List<EnemyConnector>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple instances of EManager detected. Destroying duplicate.");
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddEnemy(EnemyConnector enemy)
    {
        enemies.Add(enemy);
    }
    public void RemoveEnemy(EnemyConnector enemyConnector)
    {
        enemies.Remove(enemyConnector);
    }
    
    public List<EnemyConnector> GetEnemies()
    {
        return enemies;
    }

    public void SetEnemies(List<EnemyConnector> inEnemies)
    {
        this.enemies = inEnemies;
    }

    
}
