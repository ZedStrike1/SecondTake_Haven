using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public int attackDamage = 10;
    public float attackRange = 1.2f;
    public LayerMask enemyLayer;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
 
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            MusuhSederhana m = enemy.GetComponent<MusuhSederhana>();
            if (m != null)
            {
                m.TakeDamage(attackDamage);
            }
        }
    }

    public void IncreaseDamage(int bonus)
    {
        attackDamage += bonus;
        Debug.Log("Damage naik menjadi: " + attackDamage);
    }
}