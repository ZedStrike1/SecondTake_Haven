using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private UIManager uiManager;

    void Start()
    {
        currentHealth = maxHealth;
        uiManager = FindFirstObjectByType<UIManager>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player kena damage! Sisa HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            if (uiManager != null)
            {
                uiManager.TampilkanRespawn();
            }
        }
    }
}