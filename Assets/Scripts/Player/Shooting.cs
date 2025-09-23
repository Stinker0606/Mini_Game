using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // Hier ziehen wir das Projektil-Prefab rein
    public GameObject bulletPrefab;

    // Ein leerer Punkt vor dem Spieler, von wo aus geschossen wird
    public Transform firePoint;

    void Update()
    {
        // Wenn die linke Maustaste gedr�ckt wird
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // 1. Erstelle das Projektil am firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // 2. Hole dir die Skript-Komponente vom NEU ERSTELLTEN Projektil
        Bullet bulletScript = bullet.GetComponent<Bullet>();

        // 3. Rufe die SetDirection-Methode auf und �bergib die Vorw�rts-Richtung des firePoints
        if (bulletScript != null)
        {
            bulletScript.SetDirection(firePoint.forward);
        }
    }
}