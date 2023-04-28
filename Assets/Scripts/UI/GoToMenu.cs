using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour
{
    public void OpenGame()
    {
        SceneManager.LoadScene(0);
    }
}
