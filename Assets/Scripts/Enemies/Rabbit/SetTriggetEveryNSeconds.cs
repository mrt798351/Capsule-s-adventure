using UnityEngine;

public class SetTriggetEveryNSeconds : MonoBehaviour
{
    [SerializeField] private float _attackPeriod = 7f;
    [SerializeField] private Animator _anim;

    private float _timer;

    [SerializeField] private string _triggerName = "Attack";

    private void Update()
    {
        _timer += Time.deltaTime;
        if(_timer > _attackPeriod)
        {
            _timer = 0;
            _anim.SetTrigger(_triggerName);
        }
    }
}
