using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpForce = 12f;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

void Update()
{
    float move = 0;

    if (Input.GetKey(KeyCode.A))
        move = -1;

    if (Input.GetKey(KeyCode.D))
        move = 1;

    rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
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
