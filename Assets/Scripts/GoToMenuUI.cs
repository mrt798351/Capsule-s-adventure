using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenuUI : MonoBehaviour
{
    public void OpenGame()
    {
        SceneManager.LoadScene(0);
    }
}
