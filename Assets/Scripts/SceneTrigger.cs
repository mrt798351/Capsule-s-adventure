using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    [SerializeField] private string sceneName; // The name of the scene to transition to

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player has entered the trigger
        {
            SceneManager.LoadScene(sceneName); // Load the specified scene
        }
    }
}