using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int crystalCount = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void AddCrystal()
    {
        crystalCount++;

        Debug.Log("Crystal : " + crystalCount);
    }
}
