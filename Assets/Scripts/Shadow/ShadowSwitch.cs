using UnityEngine;

public class ShadowSwitch : MonoBehaviour
{
    private bool activated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (activated)
            return;

        if (collision.CompareTag("Shadow"))
        {
            activated = true;

            PuzzleManager.Instance.shadowSwitchActivated = true;

            Debug.Log("Shadow Switch Activated");
        }
    }
}
