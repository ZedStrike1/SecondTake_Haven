using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Status Serangan")]
    public int attackDamage = 10;
    public float attackRange = 0.8f;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    [Header("Cooldown Serang")]
    public float attackRate = 2f;
    private float nextAttackTime = 0f;

    private UIManager uiManager;
    private PlayerHealth playerHealth;

    void Start()
    {
        uiManager = FindFirstObjectByType<UIManager>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.J))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        Vector2 posisiSerang = (attackPoint != null) ? attackPoint.position : transform.position;

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(posisiSerang, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            MusuhSederhana musuh = enemy.GetComponent<MusuhSederhana>();
            if (musuh != null)
            {
                musuh.TakeDamage(attackDamage);
            }
        }
    }

    public void IncreaseDamage(int bonusDamage)
    {
        attackDamage += bonusDamage;
        Debug.Log("Damage naik menjadi: " + attackDamage);

        if (uiManager != null && playerHealth != null)
        {
            uiManager.UpdateUIStatus(playerHealth.currentHealth, playerHealth.maxHealth, attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Vector2 posisiSerang = (attackPoint != null) ? attackPoint.position : transform.position;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(posisiSerang, attackRange);
    }
}