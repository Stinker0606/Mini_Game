using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speedToMove = 2.0f;
    public GameObject player;

    // Wir benötigen den Rigidbody, um später die Rotationsachse einzufrieren
    private Rigidbody rb;

    private Animator animator;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update wird für die Bewegung genutzt, genau wie im SimpleMovement-Skript
    void Update()
    {
        if (player != null)
        {
            // Bestimme den Richtungsvektor vom Gegner zum Spieler
            Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;

            // Ignoriere die y-Komponente für die Bewegung, damit der Gegner auf dem Boden bleibt
            Vector3 movementDirection = new Vector3(directionToPlayer.x, 0, directionToPlayer.z);
            
            if (animator != null)
            {
                animator.SetFloat("Velocity", movementDirection.magnitude * speedToMove);
            }
            // Bewege den Gegner mit transform.Translate.
            transform.Translate(movementDirection * speedToMove * Time.deltaTime, Space.World);

            // Rotiere den Gegner so, dass er zum Spieler schaut
            Vector3 lookDirection = new Vector3(directionToPlayer.x, 0, directionToPlayer.z);

            if (lookDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(lookDirection);
            }
        }
    }

    public void SetTarget(GameObject target)
    {
        this.player = target;
    }
}