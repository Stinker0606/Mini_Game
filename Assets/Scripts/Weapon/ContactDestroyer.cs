using UnityEngine;

public class ContactDestroyer : MonoBehaviour
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
        HPSystem hpScript = other.gameObject.GetComponent<HPSystem>();

        if (hpScript != null)
        {
            hpScript.TakeDamage(hpScript.incomingDamage);
        }
        else
        {
        }

        Destroy(gameObject);
    }
}
