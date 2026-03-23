using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 5f;

    private Rigidbody2D rb;
    private Animator animator;
    private bool facingRight = true;

    private readonly int playerSpeedID = Animator.StringToHash("PlayerSpeed");

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = new Vector2(moveInput * playerSpeed, rb.linearVelocity.y);
        rb.linearVelocity = velocity;

        // Animación
        animator.SetFloat(playerSpeedID, Mathf.Abs(velocity.x));

        
        if (moveInput > 0 && !facingRight)
            Flip();
        else if (moveInput < 0 && facingRight)
            Flip();
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
