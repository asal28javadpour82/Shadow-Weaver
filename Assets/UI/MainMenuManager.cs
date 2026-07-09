using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // دکمه Start
    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Stage1");
    }

    // دکمه Exit
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}