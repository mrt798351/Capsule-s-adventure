using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _spawn;
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private float _shotPeriod = 0.2f;

    private float _timer;

    [SerializeField] private ParticleSystem _shotEffect;

    [SerializeField] private AudioSource _shotSound;
    [SerializeField] private GameObject _flash;

    private void Update()
    {
        _timer += Time.unscaledDeltaTime;
        if (_timer > _shotPeriod)
        {
            if(Input.GetMouseButton(0)) 
            {
                _timer = 0;
                Shot();
            }
        }
    }

    public virtual void Shot()
    {
        GameObject newBullet = Instantiate(_bulletPrefab, _spawn.position, _spawn.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = _spawn.forward * _bulletSpeed;
        _shotSound.Play();
        _flash.SetActive(true);

        Invoke(nameof(HideFlash), 0.08f);
        _shotEffect.Play();
    }

    public void HideFlash()
    {
        _flash.SetActive(false);
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }
    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }
    public virtual void AddBullets(int numOfBullets)
    {
        
    }
}