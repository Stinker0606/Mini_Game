using UnityEngine;

public class AutoDestroyScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float lifetime = 5.0f; // Lebensdauer in Sekunden
    void Start()
    {
        Destroy(gameObject, lifetime); // Zerstört das GameObject nach der angegebenen Lebensdauer  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
