using UnityEngine;

public enum RopeState
{
    Disabled,
    Fly,
    Active
}
public class RopeGun : MonoBehaviour
{
    [SerializeField] private Hook _hook;
    [SerializeField] private Transform _spawn;
    [SerializeField] private float _speed;

    [SerializeField] private SpringJoint _springJoint;

    [SerializeField] private Transform _ropeStart;

    [SerializeField] private RopeState _currenetRopeState;

    [SerializeField] private RopeRenderer _ropeRenderer;

    [SerializeField] private PlayerMovement _playerMovement;

    private float _length;

    private void Update()
    {
        if(Input.GetMouseButtonDown(2))
        {
            Shot();
        }
        if(_currenetRopeState == RopeState.Fly)
        {
            float distance = Vector3.Distance(_ropeStart.position, _hook.transform.position);
            if(distance > 20f) 
            {
                _hook.gameObject.SetActive(false);
                _currenetRopeState = RopeState.Disabled;
                _ropeRenderer.Hide();
            }
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(_currenetRopeState == RopeState.Active)
            {
                if(_playerMovement._isGrounded == false)
                {
                    _playerMovement.Jump();
                }
            }
            DestroySpring();
        }
        if(_currenetRopeState == RopeState.Fly || _currenetRopeState == RopeState.Active)
        {
            _ropeRenderer.Draw(_ropeStart.position, _hook.transform.position, _length);
        }
    }

    private void Shot()
    {
        _length = 1;

        if(_springJoint)
        {
            Destroy(_springJoint);
        }

        _hook.gameObject.SetActive(true);

        _hook.StopFix();

        _hook.transform.position = _spawn.position;
        _hook.transform.rotation = _spawn.rotation;
        _hook._rb.velocity = _spawn.forward * _speed;

        _currenetRopeState = RopeState.Fly;
    }

    public void CreateSpring()
    {
        if(_springJoint == null)
        {
            _springJoint = gameObject.AddComponent<SpringJoint>();

            _springJoint.connectedBody = _hook._rb;
            _springJoint.anchor = _ropeStart.localPosition;
            _springJoint.autoConfigureConnectedAnchor = false;
            _springJoint.connectedAnchor = Vector3.zero;
            _springJoint.spring = 100f;
            _springJoint.damper = 5f;

            _length = Vector3.Distance(_ropeStart.position, _hook.transform.position);
            _springJoint.maxDistance = _length;

            _currenetRopeState = RopeState.Active;
        }
    }
    public void DestroySpring()
    {
        if(_springJoint)
        {
            Destroy(_springJoint);
            _currenetRopeState = RopeState.Disabled;
            _hook.gameObject.SetActive(false);
            _ropeRenderer.Hide();
        }
    }
}
