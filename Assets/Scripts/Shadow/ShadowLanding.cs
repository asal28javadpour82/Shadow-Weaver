using UnityEngine;

public class ShadowLanding : MonoBehaviour
{
    private PlayerController playerController;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
            return;

        Debug.Log("Shadow Landed");

        // فعلاً همان رفتار قبلی حفظ می‌شود
        if (playerController != null)
        {
            playerController.enabled = true;
        }

        // در آینده ShadowManager اینجا را مدیریت خواهد کرد.
    }
}
