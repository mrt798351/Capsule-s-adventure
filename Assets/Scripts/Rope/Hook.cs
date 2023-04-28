using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] private Collider _collider;
    [SerializeField] private Collider _playerCollider;

    [SerializeField] private RopeGun _ropeGun;

    private FixedJoint _fixedJoint;

    public Rigidbody _rb;

    private void Start()
    {
        Physics.IgnoreCollision(_collider, _playerCollider);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_fixedJoint == null)
        {
            _fixedJoint = gameObject.AddComponent<FixedJoint>();

            if (collision.rigidbody)
            {
                _fixedJoint.connectedBody = collision.rigidbody;
            }
            _ropeGun.CreateSpring();
        }
    }

    public void StopFix()
    {
        if (_fixedJoint) 
        {
            Destroy(_fixedJoint);
        }
    }
}
