using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static WaveManager instance { get; private set; }
    private List<WaveSpawnerSimple> waves = new List<WaveSpawnerSimple>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple instances of WManager detected. Destroying duplicate.");
        }
    }
    public void AddWaveSpawner(WaveSpawnerSimple inW)
    {
        waves.Add(inW);
    }
    public void RemoveWaveSpawner(WaveSpawnerSimple inW)
    {
        waves.Remove(inW);
    }

    public List<WaveSpawnerSimple> GetWaveSpawner()
    {
        return waves;
    }

    public void SetWaveSpawner(List<WaveSpawnerSimple> inEnemies)
    {
        this.waves = inEnemies;
    }
}