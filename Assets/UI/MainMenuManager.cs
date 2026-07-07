using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Start Game Button Pressed");
    }

    public void ExitGame()
    {
        Debug.Log("Exit Button Pressed");

        Application.Quit();
    }
}
