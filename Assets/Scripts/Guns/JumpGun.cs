using UnityEngine;

public class JumpGun : MonoBehaviour
{
    [SerializeField] private ChargeIcon _chargeIcon;

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Transform _spawn;

    [SerializeField] private Gun _pistol;

    [SerializeField] private float _speed;

    [SerializeField] private float _maxCharge = 3f;
    private float _currentCharge;
    private bool _isCharged;

    private void Update()
    {
        _currentCharge += Time.deltaTime;

        if(_isCharged )
        {
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                _rb.AddForce(-_spawn.forward * _speed, ForceMode.VelocityChange);
                _pistol.Shot();
                _isCharged = false;
                _currentCharge = 0;
                _chargeIcon.StartCharge();
            }
        }
        else
        {
            _currentCharge += Time.unscaledDeltaTime;
            _chargeIcon.SetChargeValue(_currentCharge, _maxCharge);
            if(_currentCharge >= _maxCharge)
            {
                _isCharged = true;
                _chargeIcon.StopCharge();
            }
        }
    }
}
