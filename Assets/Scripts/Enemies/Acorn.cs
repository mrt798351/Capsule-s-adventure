using Unity.VisualScripting;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private float _maxRotSpeed;

    private void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(_velocity, ForceMode.VelocityChange);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(
            Random.Range(-_maxRotSpeed, _maxRotSpeed),
            Random.Range(-_maxRotSpeed, _maxRotSpeed),
            Random.Range(-_maxRotSpeed, _maxRotSpeed)
            );
    }
}
