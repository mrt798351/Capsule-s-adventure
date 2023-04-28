using UnityEngine;

public class Hen : MonoBehaviour
{
    private Transform _playerTarget;

    [SerializeField] private Rigidbody _rb;

    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _timeToReachSpeed = 1f;

    private void Start()
    {
        _playerTarget = FindAnyObjectByType<PlayerMovement>().transform;
    }

    private void FixedUpdate()
    {
        Vector3 toPlayer = (_playerTarget.position - transform.position).normalized;
        Vector3 force = _rb.mass * (toPlayer * _speed - _rb.velocity) / _timeToReachSpeed;

        _rb.AddForce(force);
    }
}
