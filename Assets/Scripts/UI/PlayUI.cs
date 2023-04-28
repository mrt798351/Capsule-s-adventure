using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayUI : MonoBehaviour
{
    public void OpenGame()
    {
        SceneManager.LoadScene(1);
    }
}
