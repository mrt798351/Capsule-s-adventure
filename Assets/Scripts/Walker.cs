using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Left,
    Right,
}

public class Walker : MonoBehaviour
{
    [SerializeField] private Transform _leftTarget;
    [SerializeField] private Transform _rightTarget;

    [SerializeField] private float _speed;


    [SerializeField] private float _stopTime;

    [SerializeField] private Direction _direction;

    private bool _isStopped;

    [SerializeField] private UnityEvent OnLeftTarget;
    [SerializeField] private UnityEvent OnRightTarget;

    [SerializeField] private Transform _rayStart;

    private void Start()
    {
        _leftTarget.parent = null; 
        _rightTarget.parent = null;
    }
    
    private void Update()
    {
        if(_isStopped == true)
        {
            return;
        }

        if(_direction == Direction.Left)
        {
            transform.position -= new Vector3(Time.deltaTime * _speed, 0f, 0f);

            if(transform.position.x < _leftTarget.position.x)
            {
                _direction = Direction.Right;
                _isStopped = true;
                Invoke(nameof(ContinueWalk), _stopTime);
                OnLeftTarget.Invoke();
            }
        }
        else
        {
            transform.position += new Vector3(Time.deltaTime * _speed, 0f, 0f);

            if (transform.position.x > _rightTarget.position.x)
            {
                _direction = Direction.Left;
                _isStopped = true;
                Invoke(nameof(ContinueWalk), _stopTime);
                OnRightTarget.Invoke();
            }
        }
        RaycastHit hit;
        if(Physics.Raycast(_rayStart.position, Vector3.down, out hit))
        {
            transform.position = hit.point;
        }
    }
    private void ContinueWalk()
    {
        _isStopped = false;
    }
}
