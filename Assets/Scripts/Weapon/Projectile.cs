using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 40f;

    private Vector3 flightDirection;
    public void SetDirection(Vector3 newDirection)
    {
        flightDirection = newDirection.normalized;
    }

    // Update wird einmal pro Frame aufgerufen
    void Update()
    {
        if (flightDirection != Vector3.zero)
        {
            transform.Translate(flightDirection * speed * Time.deltaTime, Space.World);
        }
    }
}