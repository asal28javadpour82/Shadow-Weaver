using UnityEngine;
using UnityEngine.SceneManagement;

public class StageCompleteManager : MonoBehaviour
{
    public static StageCompleteManager Instance;

    [Header("UI")]
    public GameObject stageCompletePanel;

    [Header("Scene Settings")]
    public int nextSceneIndex;

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
        if (levelCompleted)
            return;

        levelCompleted = true;

        stageCompletePanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void NextStage()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
