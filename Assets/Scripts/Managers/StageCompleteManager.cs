using UnityEngine;
using UnityEngine.SceneManagement;

public class StageCompleteManager : MonoBehaviour
{
    public static StageCompleteManager Instance;

    [Header("UI")]
    public GameObject stageCompletePanel;

    private bool levelCompleted = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        stageCompletePanel.SetActive(false);
    }

public void CompleteLevel()
{
    Debug.Log("COMPLETE LEVEL CALLED");

    if (levelCompleted)
        return;

    levelCompleted = true;

    stageCompletePanel.SetActive(true);

    Time.timeScale = 0f;
}

    public void NextStage()
    {
        // ادامه زمان
        Time.timeScale = 1f;

        // فعلاً فقط Stage2 را لود می‌کند
        SceneManager.LoadScene("Stage2");
    }
}
