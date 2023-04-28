using UnityEngine;

public class OpenWinWindowUI : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] _disableComponents;

    [SerializeField] private GameObject _winWindow;

    public void ShowWinWindow()
    {
        _winWindow.SetActive(true);
        for (int i = 0; i < _disableComponents.Length; i++)
        {
            _disableComponents[i].enabled = false;
        }
        Time.timeScale = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ShowWinWindow();
        }
    }
}
