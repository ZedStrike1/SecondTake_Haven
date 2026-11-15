using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private UIManager uiManager;
    private PlayerCombat playerCombat;

    void Start()
    {
        currentHealth = maxHealth;
        uiManager = FindFirstObjectByType<UIManager>();
        playerCombat = GetComponent<PlayerCombat>();

        UpdateHUD();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        Debug.Log("Player kena damage! Sisa HP: " + currentHealth);
        UpdateHUD();

        if (currentHealth <= 0)
        {
            if (uiManager != null)
            {
                uiManager.TampilkanRespawn();
            }
        }
    }

    void UpdateHUD()
    {
        if (uiManager != null)
        {
            int dmg = (playerCombat != null) ? playerCombat.attackDamage : 0;
            uiManager.UpdateUIStatus(currentHealth, maxHealth, dmg);
        }
    }
}