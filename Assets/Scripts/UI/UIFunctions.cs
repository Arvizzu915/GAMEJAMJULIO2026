using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFunctions : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("LevelManager");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
