using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isOpen = false;

    private Collider2D doorCollider;
    private SpriteRenderer doorSprite;

    private void Awake()
    {
        doorCollider = GetComponent<Collider2D>();
        doorSprite = GetComponent<SpriteRenderer>();
    }

    public void OpenDoor()
    {
        if (isOpen)
            return;

        isOpen = true;

        Debug.Log("Door Opened");

        // پخش صدای باز شدن در
        if (AudioManager.Instance != null)
            AudioManager.Instance.PlayDoor();

        // تغییر رنگ در
        if (doorSprite != null)
            doorSprite.color = Color.green;

        // نمایش صفحه پایان مرحله
        if (StageCompleteManager.Instance != null)
            StageCompleteManager.Instance.CompleteLevel();
    }
}
