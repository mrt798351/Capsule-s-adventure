using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private UnityEvent _onTakeDamage;
    [SerializeField] private UnityEvent _onDie;

    [SerializeField] private int _health = 1;

    public void TakeDamage(int damageValue)
    {
        _health -= damageValue;
        if (_health <= 0)
        {
            Die();
        }
        _onTakeDamage.Invoke();
    }
    public void Die()
    {
        Destroy(gameObject);
        _onDie.Invoke();
    }
}
