using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHP : HPSystem
{
    // Verweis auf die UI-Text-Komponente
    public TextMeshProUGUI hpText;

    // Timer f�r die Lebensregeneration
    private float timeSinceLastDamage = 2f;
    [SerializeField] private int regenDelay = 5; // Zeit in Sekunden, bevor die Regeneration beginnt
    [SerializeField] private int regenAmount = 1; // Wie viel HP pro Sekunde regeneriert wird

    private bool isDead = false;

    void Update()
    {
        // UI-Text aktualisieren
        if (hpText != null)
        {
            hpText.text = "HP: " + currentHP.ToString();
        }

        // Wenn der Spieler nicht tot ist und keine Lebenspunkte mehr hat
        if (!isDead && currentHP <= 0)
        {
            Die();
        }

        // Timer f�r die Regeneration aktualisieren
        timeSinceLastDamage += Time.deltaTime;

        // Wenn der Timer den Schwellenwert �berschreitet, starte die Regeneration
        if (timeSinceLastDamage >= regenDelay)
        {
            // Regeneriert nur, wenn die Lebenspunkte nicht voll sind
            if (currentHP < 100f)
            {
                currentHP += regenAmount * Time.deltaTime;
                // Stellt sicher, dass die Lebenspunkte nicht �ber den Maximalwert steigen
                currentHP = Mathf.Min(currentHP, 100f);
            }
        }
    }

    // �berschreiben der TakeDamage-Methode, um den Timer zur�ckzusetzen
    public new void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        timeSinceLastDamage = 0f; // Setze den Timer zur�ck, wenn Schaden genommen wurde
    }

    // Eigene Die()-Methode, die nur f�r den Spieler gilt
    private void Die()
    {
        isDead = true;

        // Zerst�rt das GameObject und l�dt die Szene
        Destroy(gameObject);
        SceneManager.LoadScene("DeathScreen");
    }
}