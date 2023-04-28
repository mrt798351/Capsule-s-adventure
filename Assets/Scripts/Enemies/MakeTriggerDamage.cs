using UnityEngine;

public class MakeTriggerDamage : MonoBehaviour
{
    [SerializeField] private int _damageValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<PlayerHealth>())
            {
                other.attachedRigidbody.GetComponent<PlayerHealth>().TakeDamage(_damageValue);
            }
        }
    }
}
