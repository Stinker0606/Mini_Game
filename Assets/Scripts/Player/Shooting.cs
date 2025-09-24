using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // Hier ziehen wir das Projektil-Prefab rein
    public GameObject bulletPrefab;

    // Ein leerer Punkt vor dem Spieler, von wo aus geschossen wird
    public Transform firePoint;

    // Ein Timer, um zu steuern, wie schnell wir schießen
    private float fireTimer = 0.0f;
    [SerializeField] private float fireRate = 0.1f; // Zeit zwischen den Schüssen

    void Update()
    {
        // Wenn die linke Maustaste gedrückt wird
        if (Input.GetButton("Fire1"))
        {
            // Schuss-Timer aktualisieren
            fireTimer += Time.deltaTime;

            if (fireTimer >= fireRate)
            {
                Shoot();
                fireTimer = 0f; // Setze den Timer zurück für den nächsten Schuss
            }
        }
    }

    void Shoot()
    {
        // 1. Erstelle das Projektil am firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // 2. Hole dir die Skript-Komponente vom NEU ERSTELLTEN Projektil
        Bullet bulletScript = bullet.GetComponent<Bullet>();

        // 3. Rufe die SetDirection-Methode auf und übergib die Vorwärts-Richtung des firePoints
        if (bulletScript != null)
        {
            bulletScript.SetDirection(firePoint.forward);
        }
    }
}