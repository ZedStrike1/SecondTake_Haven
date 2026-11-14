using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();       
    }

    void Update()
    {
        // wasd
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        //ngitung vector gitu sgala
        moveInput = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        //perhitungan supaya smooth
        rb.linearVelocity = moveInput * moveSpeed; 
    }
}
