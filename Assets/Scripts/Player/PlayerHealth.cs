using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    private bool isDead = false;

    // آخرین محل Checkpoint
    private Vector3 checkpointPosition;

    // کامپوننت‌ها
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Collider2D playerCollider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();

        checkpointPosition = transform.position;
    }

    public void Die()
    {
        if (isDead)
            return;

        isDead = true;

        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        // 🔊 پخش صدای باخت
        AudioManager.Instance.PlayGameOver();

        // مخفی شدن بازیکن
        spriteRenderer.enabled = false;

        // غیرفعال شدن برخورد
        playerCollider.enabled = false;

        // توقف فیزیک
        rb.velocity = Vector2.zero;
        rb.simulated = false;

        // صبر
        yield return new WaitForSeconds(2f);

        // برگشت به آخرین Checkpoint
        transform.position = checkpointPosition;

        // فعال شدن دوباره فیزیک
        rb.simulated = true;

        // ظاهر شدن
        spriteRenderer.enabled = true;

        // فعال شدن برخورد
        playerCollider.enabled = true;

        isDead = false;
    }

    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        checkpointPosition = newCheckpoint;
    }
}
