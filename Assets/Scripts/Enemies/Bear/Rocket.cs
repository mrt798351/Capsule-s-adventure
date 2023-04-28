using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotSpeed;

    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMovement>().transform;
    }
    private void Update()
    {
        transform.position += Time.deltaTime * transform.forward * _speed;
        Vector3 toPlayer = _playerTransform.position - transform.position;
        Quaternion targetRot = Quaternion.LookRotation(toPlayer, Vector3.forward);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * _rotSpeed);
    }
}
