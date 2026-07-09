using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Movement")]
    public Transform leftPoint;
    public Transform rightPoint;
    public float moveSpeed = 2f;

    [Header("Enemy Light")]
    public Transform enemyLight;
    public float lightOffset = 0.35f;

    private SpriteRenderer spriteRenderer;
    private bool movingRight = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        FaceRight();
    }

    void Update()
    {
        if (movingRight)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;

            if (transform.position.x >= rightPoint.position.x)
            {
                movingRight = false;
                FaceLeft();
            }
        }
        else
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;

            if (transform.position.x <= leftPoint.position.x)
            {
                movingRight = true;
                FaceRight();
            }
        }
    }

void FaceRight()
{
    spriteRenderer.flipX = true;

    if (enemyLight != null)
    {
        // جلوى حلزون
        enemyLight.localPosition = new Vector3(lightOffset, 0f, 0f);
    }
}

void FaceLeft()
{
    spriteRenderer.flipX = false;

    if (enemyLight != null)
    {
        // پشت حلزون
        enemyLight.localPosition = new Vector3(lightOffset, 0f, 0f);
    }
}
}
