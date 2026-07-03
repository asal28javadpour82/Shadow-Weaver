using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Door Settings")]
    public int requiredCrystals = 1;

    private bool isOpen = false;

    private void Update()
    {
        if (isOpen)
            return;

        if (GameManager.Instance == null)
            return;

        if (GameManager.Instance.crystalCount >= requiredCrystals)
        {
            isOpen = true;

            Debug.Log("Door Opened");
        }
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
