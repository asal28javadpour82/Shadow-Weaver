using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isOpen = false;

    public void OpenDoor()
    {
        if (isOpen)
            return;

        isOpen = true;

        Debug.Log("Door Opened");

        // فعلاً فقط پیام چاپ می‌کنیم.
        // بعداً انیمیشن و صدا هم اضافه می‌کنیم.
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
