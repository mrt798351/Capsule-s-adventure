using UnityEngine;

public class TakeCollisionDamage : MonoBehaviour
{
    [SerializeField] private EnemyHealth enemyHealth;

    private bool _dieOnAnyCollision = true;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.rigidbody)
        {
            if(collision.rigidbody.GetComponent<Bullet>())
            {
                enemyHealth.TakeDamage(1);
            }
        }

        if(_dieOnAnyCollision == true)
        {
            enemyHealth.TakeDamage(10000);
        }
    }
}
