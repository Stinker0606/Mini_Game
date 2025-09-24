using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HPSystem hpScript = other.gameObject.GetComponent<HPSystem>();

            if (hpScript != null)
            {
                hpScript.TakeDamage(hpScript.incomingDamage);
            }
        }
    }
}
