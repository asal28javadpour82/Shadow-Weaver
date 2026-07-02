using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform leftPoint;
    public Transform rightPoint;
    public float moveSpeed = 2f;

    private SpriteRenderer spriteRenderer;
    private bool movingRight = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = true;   // اگر حرکت اولیه به راست است
    }

    void Update()
    {
        if (movingRight)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;

            if (transform.position.x >= rightPoint.position.x)
            {
                movingRight = false;
                spriteRenderer.flipX = false;
            }
        }
        else
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;

            if (transform.position.x <= leftPoint.position.x)
            {
                movingRight = true;
                spriteRenderer.flipX = true;
            }
        }
    }
}
