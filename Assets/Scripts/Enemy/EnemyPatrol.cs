using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform leftPoint;
    public Transform rightPoint;
    public float moveSpeed = 2f;

    // نور دشمن
    public Transform enemyLight;

    private SpriteRenderer spriteRenderer;
    private bool movingRight = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // حرکت اولیه به سمت راست
        spriteRenderer.flipX = true;

        if (enemyLight != null)
        {
            enemyLight.localPosition = new Vector3(0.8f, 0f, 0f);
        }
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

                if (enemyLight != null)
                {
                    enemyLight.localPosition = new Vector3(-0.8f, 0f, 0f);
                }
            }
        }
        else
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;

            if (transform.position.x <= leftPoint.position.x)
            {
                movingRight = true;

                spriteRenderer.flipX = true;

                if (enemyLight != null)
                {
                    enemyLight.localPosition = new Vector3(0.8f, 0f, 0f);
                }
            }
        }
    }
}
