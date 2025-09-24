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

    // Variable, um zu überprüfen, ob der Spieler zielt
    public bool isAiming = false;

    // Streuung (Bloom) beim Schießen aus der Hüfte
    [SerializeField] private float hipFireSpread = 0.1f;

    void Update()
    {
        // Wenn die linke Maustaste gedrückt wird
        if (Input.GetMouseButton(0))
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
        // 1. Die Basisrichtung ist die Vorwärtsrichtung des Feuerpunkts
        Vector3 finalDirection = firePoint.forward;

        // 2. Überprüfen, ob der Spieler zielt (wir verwenden die Klassenvariable)
        if (!isAiming)
        {
            // Erstellt einen zufälligen Vektor in einer Kugel mit dem Radius 'hipFireSpread'
            Vector3 randomSpread = Random.insideUnitSphere * hipFireSpread;
            finalDirection += randomSpread;
        }

        // 3. Erstelle das Projektil am firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // 4. Hole dir die Skript-Komponente vom NEU ERSTELLTEN Projektil
        Bullet bulletScript = bullet.GetComponent<Bullet>();

        // 5. Rufe die SetDirection-Methode auf und übergib die endgültige Richtung (FinalDirection)
        if (bulletScript != null)
        {
            bulletScript.SetDirection(finalDirection.normalized);
        }
    }
}