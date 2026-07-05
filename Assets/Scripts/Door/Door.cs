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

        if (doorCollider != null)
           // doorCollider.enabled = false;

        if (doorSprite != null)
            doorSprite.color = Color.green;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isOpen)
            return;

        if (collision.CompareTag("Player"))
        {
            Debug.Log("LEVEL COMPLETE");
        }
    }
}
