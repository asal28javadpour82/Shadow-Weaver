using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    private bool activated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (activated)
            return;

        if (collision.CompareTag("Player"))
        {
            activated = true;

            PuzzleManager.Instance.playerSwitchActivated = true;

            Debug.Log("Player Switch Activated");
        }
    }
}
