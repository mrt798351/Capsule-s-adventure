using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] _disableComponents;

    [SerializeField] private PlayerHealth _playerHealth;

    [SerializeField] private GameObject _menuButton;
    [SerializeField] private GameObject _menuWindow;

    [SerializeField] private GameObject _dieWindow;


    public void OpenMenuWindow()
    {
        _menuButton.SetActive(false);
        _menuWindow.SetActive(true);
        for (int i = 0; i < _disableComponents.Length; i++)
        {
            _disableComponents[i].enabled = false;
        }
        Time.timeScale = 0f;
        //Time.timeScale = 0.01f;
    }

    public void CloseMenuWindow()
    {
        _menuButton.SetActive(true);
        _menuWindow.SetActive(false);
        for (int i = 0; i < _disableComponents.Length; i++)
        {
            _disableComponents[i].enabled = true;
        }
        Time.timeScale = 1f;
    }

    public void OpenDieWindow()
    {
        _playerHealth.Die();

        Time.timeScale = 0f;

        for (int i = 0; i < _disableComponents.Length; i++)
        {
            _disableComponents[i].enabled = false;
        }

    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
