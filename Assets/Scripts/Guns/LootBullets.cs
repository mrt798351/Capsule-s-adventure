using UnityEngine;

public class LootBullets : MonoBehaviour
{
    [SerializeField] private int _gunIndex;
    [SerializeField] private int _numOfBullets;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<PlayerArmory>())
        {
            other.attachedRigidbody.GetComponent<PlayerArmory>().AddBullets(_gunIndex, _numOfBullets);
            Destroy(gameObject);
        }
    }

}
