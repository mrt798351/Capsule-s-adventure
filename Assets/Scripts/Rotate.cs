using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private Vector3 _rotSpeed;

    private void Update()
    {
        transform.Rotate(_rotSpeed * Time.deltaTime);
    }
}
