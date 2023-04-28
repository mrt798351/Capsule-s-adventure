using UnityEngine;

public class TakeTriggerDamage : MonoBehaviour
{
    [SerializeField] private EnemyHealth enemyHealth;

    private bool _dieOnAnyCollision = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<Bullet>())
            {
                enemyHealth.TakeDamage(1);
            }
        }

        if (_dieOnAnyCollision == true)
        {
            if(other.isTrigger == false)
            {
                enemyHealth.TakeDamage(1);
            }
        }
    }

}
