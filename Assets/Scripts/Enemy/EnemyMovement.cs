using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float speedToMove = 2.0f;
    public GameObject player;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            // Bestimme den Richtungsvektor vom Gegner zum Spieler
            Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
            if (directionToPlayer.magnitude >= 1)
            {
                //Bewege den Gegner in Richtung des Spielers
                transform.Translate(directionToPlayer * speedToMove * Time.deltaTime);
            }
        }

    }


}
