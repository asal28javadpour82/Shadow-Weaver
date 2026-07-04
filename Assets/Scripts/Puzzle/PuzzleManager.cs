using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    public bool playerSwitchActivated = false;
    public bool shadowSwitchActivated = false;

    public Door door;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (playerSwitchActivated && shadowSwitchActivated)
        {
            if (door != null)
            {
                door.OpenDoor();
            }
        }
    }
}
