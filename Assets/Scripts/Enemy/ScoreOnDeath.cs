using UnityEngine;

public class ScoreOnDeath : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int scoreValue = 100;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreManager.instance.amount += scoreValue;
    }
}
