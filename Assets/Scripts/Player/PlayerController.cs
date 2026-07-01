using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6f;
    public float jumpForce = 12f;

    private Rigidbody2D rb;
    private Animator animator;

    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float move = 0f;

        if (Input.GetKey(KeyCode.A))
            move = -1f;

        if (Input.GetKey(KeyCode.D))
            move = 1f;

        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        // Animator
        animator.SetFloat("Speed", Mathf.Abs(move));
        animator.SetBool("IsGrounded", isGrounded);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Flip Player
        if (move > 0)
            transform.localScale = new Vector3(1, 1, 1);

        if (move < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
}
