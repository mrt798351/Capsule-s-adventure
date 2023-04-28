using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelPrefs : MonoBehaviour
{
    [SerializeField] private Button _startButton;

    private int _level;

    private void Start()
    {
        _level = PlayerPrefs.GetInt("level");
    }

    public void LoadTo(int level)
    {
        SceneManager.LoadScene(level);
    }
}
