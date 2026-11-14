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
            if (moveX != 0f)
            {
                lastMoveX = moveX;
                lastMoveY = 0f;
            }
            else
            {
                lastMoveX = 0f;
                lastMoveY = moveY;
            }
        }

        anim.SetFloat("Horizontal", lastMoveX);
        anim.SetFloat("Vertical", lastMoveY);
        anim.SetFloat("Speed", moveInput.sqrMagnitude);
    }

    void FixedUpdate()
    {
        //perhitungan supaya smooth
        rb.linearVelocity = moveInput * moveSpeed; 
    }
}
