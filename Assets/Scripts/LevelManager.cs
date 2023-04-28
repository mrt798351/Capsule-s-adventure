using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private const string LevelKey = "Level";
    private int currentLevel = 1;

    void Start()
    {
        if (PlayerPrefs.HasKey(LevelKey))
        {
            currentLevel = PlayerPrefs.GetInt(LevelKey);
        }
        else
        {
            PlayerPrefs.SetInt(LevelKey, currentLevel);
        }
    }

    public void SetLevel(int level)
    {
        currentLevel = level;
        PlayerPrefs.SetInt(LevelKey, currentLevel);
    }

    public int GetLevel()
    {
        return currentLevel;
    }

    public void ClearLevel()
    {
        currentLevel = 1;
        PlayerPrefs.DeleteKey(LevelKey);
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt(LevelKey, currentLevel);
        PlayerPrefs.Save();
    }
}