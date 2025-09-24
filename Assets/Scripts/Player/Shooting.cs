using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // Hier ziehen wir das Projektil-Prefab rein
    public GameObject bulletPrefab;

    // Ein leerer Punkt vor dem Spieler, von wo aus geschossen wird
    public Transform firePoint;

    // Ein Timer, um zu steuern, wie schnell wir schie�en
    private float fireTimer = 0.0f;
    [SerializeField] private float fireRate = 0.1f; // Zeit zwischen den Sch�ssen

    // Variable, um zu �berpr�fen, ob der Spieler zielt
    public bool isAiming = false;

    // Streuung (Bloom) beim Schie�en aus der H�fte
    [SerializeField] private float hipFireSpread = 0.1f;

    void Update()
    {
        // Wenn die linke Maustaste gedr�ckt wird
        if (Input.GetMouseButton(0))
        {
            // Schuss-Timer aktualisieren
            fireTimer += Time.deltaTime;

            if (fireTimer >= fireRate)
            {
                Shoot();
                fireTimer = 0f; // Setze den Timer zur�ck f�r den n�chsten Schuss
            }
        }
    }

    void Shoot()
    {
        // 1. Die Basisrichtung ist die Vorw�rtsrichtung des Feuerpunkts
        Vector3 finalDirection = firePoint.forward;

        // 2. �berpr�fen, ob der Spieler zielt (wir verwenden die Klassenvariable)
        if (!isAiming)
        {
            // Erstellt einen zuf�lligen Vektor in einer Kugel mit dem Radius 'hipFireSpread'
            Vector3 randomSpread = Random.insideUnitSphere * hipFireSpread;
            finalDirection += randomSpread;
        }

        // 3. Erstelle das Projektil am firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // 4. Hole dir die Skript-Komponente vom NEU ERSTELLTEN Projektil
        Bullet bulletScript = bullet.GetComponent<Bullet>();

        // 5. Rufe die SetDirection-Methode auf und �bergib die endg�ltige Richtung (FinalDirection)
        if (bulletScript != null)
        {
            bulletScript.SetDirection(finalDirection.normalized);
        }
    }
}