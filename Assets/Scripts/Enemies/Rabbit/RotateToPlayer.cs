using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 _leftEuler;
    [SerializeField] private Vector3 _rightEuler;

    [SerializeField] private float _rotSpeed = 5f;

    private Transform _playerTransform;

    private Vector3 _targetEuler;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMovement>().transform; 
    }

    private void Update()
    {
        if(transform.position.x < _playerTransform.position.x)
        {
            //right
            _targetEuler = _rightEuler;
        }
        else
        {
            _targetEuler = _leftEuler;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_targetEuler), Time.deltaTime * _rotSpeed);
    }
}
