using System.Collections;
using UnityEngine;

public class MusuhSederhana : MonoBehaviour
{
    public bool isBoss = false;
    public int hp = 30;
    public int damageKePlayer = 10;
    public float kecepatan = 2f;
    public float jarakPatroli = 3f;

    private Vector2 posisiAwal;
    private int arah = 1;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private ArenaManager arenaManager;
    private float cooldownSerang = 0f;

    void Start()
    {
        posisiAwal = transform.position;
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        arenaManager = FindFirstObjectByType<ArenaManager>();
    }

    void FixedUpdate()
    {
        if (cooldownSerang > 0) cooldownSerang -= Time.fixedDeltaTime;

        rb.linearVelocity = new Vector2(arah * kecepatan, 0f);

        if (transform.position.x >= posisiAwal.x + jarakPatroli)
        {
            arah = -1;
            if (sprite != null) sprite.flipX = true;
        }
        else if (transform.position.x <= posisiAwal.x - jarakPatroli)
        {
            arah = 1;
            if (sprite != null) sprite.flipX = false;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && cooldownSerang <= 0f)
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageKePlayer);
                cooldownSerang = 1f;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        StartCoroutine(KedipMerah());

        if (hp <= 0)
        {
            if (arenaManager != null)
            {
                if (isBoss) arenaManager.OnBossKilled();
                else arenaManager.OnMinionKilled();
            }
            Destroy(gameObject);
        }
    }

    IEnumerator KedipMerah()
    {
        if (sprite != null) sprite.color = Color.red;
        yield return new WaitForSeconds(0.15f);
        if (sprite != null) sprite.color = Color.white;
    }
}