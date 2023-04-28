using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    public List<ActivateByDistance> _objectsToActivate = new List<ActivateByDistance>();

    private void Update()
    {
        for (int i = 0; i < _objectsToActivate.Count; i++)
        {
            _objectsToActivate[i].CheckDistance(_playerTransform.position);
        }
    }
}
