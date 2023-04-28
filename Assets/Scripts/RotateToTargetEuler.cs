using UnityEngine;

public class RotateToTargetEuler : MonoBehaviour
{
    [SerializeField] private Vector3 _leftEuler;
    [SerializeField] private Vector3 _rightEuler;

    [SerializeField] private float _rotSpeed;

    private Vector3 _targetEuler;

    private void Update()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(_targetEuler), Time.deltaTime * _rotSpeed);
    }

    public void RotateLeft()
    {
        _targetEuler= _leftEuler;
    }
    public void RotateRight()
    {
        _targetEuler= _rightEuler;
    }
}
