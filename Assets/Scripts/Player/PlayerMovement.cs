using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpSpeed;

    [SerializeField] private float _friction;

    [SerializeField] public bool _isGrounded;

    [SerializeField] private float _maxSpeed;

    [SerializeField] private Transform _colliderTransform;

    private int _jumpFrameCounter;

    //[SerializeField] private AudioSource _jumpSound;

    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || _isGrounded == false)
        {
            _colliderTransform.localScale = Vector3.Lerp(_colliderTransform.localScale, 
                new Vector3(1f, 0.5f, 1f), Time.deltaTime * 15f);
        }
        else
        {
            _colliderTransform.localScale = Vector3.Lerp(_colliderTransform.localScale,
                new Vector3(1f, 1f, 1f), Time.deltaTime * 15f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(_isGrounded == true)
            {
                Jump();
            }
        }
    }

    public void Jump()
    {
        _rb.AddForce(0, _jumpSpeed, 0, ForceMode.VelocityChange);
        _jumpFrameCounter = 0;
        //_jumpSound.Play();
    }

    private void FixedUpdate()
    {
        float speedMul = 1f;

        if(_isGrounded == false)
        {
            speedMul = 0.2f;

            if(_rb.velocity.x > _maxSpeed && Input.GetAxis("Horizontal") > 0)
            {
                speedMul = 0;
            }

            if (_rb.velocity.x < -_maxSpeed && Input.GetAxis("Horizontal") < 0)
            {
                speedMul = 0;
            }
        }


        _rb.AddForce(Input.GetAxis("Horizontal") * _moveSpeed * speedMul, 0, 0, ForceMode.VelocityChange);

        if(_isGrounded == true)
        {
            _rb.AddForce(-_rb.velocity.x * _friction, 0, 0, ForceMode.VelocityChange);

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 15f);
        }

        _jumpFrameCounter += 1;

        if(_jumpFrameCounter == 2)
        {
            _rb.freezeRotation = false;
            _rb.AddRelativeTorque(0, 0, 10f, ForceMode.VelocityChange);
        }
    }


    private void OnCollisionStay(Collision collision)
    {
        float angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);
        if (angle < 45f)
        {
            _isGrounded = true;
            _rb.freezeRotation = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
    }

}
