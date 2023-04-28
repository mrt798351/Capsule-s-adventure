using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject _dieWindow;

    [SerializeField] private UnityEvent OnTakeDamage;

    [Header("Links")]

    [SerializeField] private HealthUI _healthUI;
    //[SerializeField] private DamageScreen _damageScreen;
    //[SerializeField] private Blink _blink;

    [Header("Health")]

    public int _health = 5;
    [SerializeField] private int _maxHealth = 10;

    [Header("Audio")]

    //[SerializeField] private AudioSource _takeDamageSound;
    [SerializeField] private AudioSource _addHealthSound;


    private void Start()
    {
        _healthUI.Setup(_maxHealth);
        _healthUI.DisplayHearts(_health);
    }

    private bool _invulnerable = false;

    public void TakeDamage(int damageValue)
    {
        if(_invulnerable == false)
        {
            _health -= damageValue;
            if(_health <= 0)
            {
                _health = 0;
                Die();
            }
            _invulnerable = true;
            Invoke(nameof(StopInvurnerable), 1f);
            //_takeDamageSound.Play();
            _healthUI.DisplayHearts(_health);
            //_damageScreen.StartDamageEffect();
            //_blink.StartBlink();

            OnTakeDamage.Invoke();
        }
    }

    private void StopInvurnerable()
    {
        _invulnerable = false;
    }

    public void AddHealth(int healthValue)
    {
        _health += healthValue;
        if(_health > _maxHealth)
        {
            _health = _maxHealth;
        }
        _addHealthSound.Play();
        _healthUI.DisplayHearts(_health);
    }

    public void Die()
    {
        Debug.Log("You died");
        Destroy(gameObject);
        _dieWindow.SetActive(true);
    }
}
