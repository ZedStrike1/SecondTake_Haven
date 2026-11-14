using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    private Animator anim;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    //nyimpen terakir kali ngadep mana
    private float lastMoveX = 0f;
    private float lastMoveY = 0f;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();       
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // wasd
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        //ngitung vector gitu sgala
        moveInput = new Vector2(moveX, moveY).normalized;

        bool isMoving = moveInput.sqrMagnitude > 0f;

        if (isMoving)
        {
            lastMoveX = moveInput.x;
            lastMoveY = moveInput.y;
        }

        anim.SetFloat("Horizontal", isMoving ? moveInput.x : lastMoveX);
        anim.SetFloat("Vertical", isMoving ? moveInput.y : lastMoveY);
        anim.SetFloat("Speed", moveInput.sqrMagnitude);
    }

    void FixedUpdate()
    {
        //perhitungan supaya smooth
        rb.linearVelocity = moveInput * moveSpeed; 
    }
}
