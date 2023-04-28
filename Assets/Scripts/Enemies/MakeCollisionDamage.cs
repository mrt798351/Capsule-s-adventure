using UnityEngine;

public class MakeCollisionDamage : MonoBehaviour
{
    [SerializeField] private int _damageValue = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.rigidbody)
        {
            if(collision.rigidbody.GetComponent<PlayerHealth>())
            {
                collision.rigidbody.GetComponent<PlayerHealth>().TakeDamage(_damageValue);
            }
        }
    }
}
