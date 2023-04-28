using UnityEngine;

public class Carrot : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed;
    private void Start()
    {
        transform.rotation = Quaternion.identity;

        Transform playerTransform = FindObjectOfType<PlayerMovement>().transform;
        Vector3 toPlayer = (playerTransform.position - transform.position).normalized;
        _rb.velocity = toPlayer * _speed;
    }
}
