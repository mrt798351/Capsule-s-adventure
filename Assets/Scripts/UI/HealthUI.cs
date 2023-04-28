using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject _heartPrefab;
    [SerializeField] private List<GameObject> _hearts = new List<GameObject>();

    public void Setup(int maxHearts)
    {
        for (int i = 0; i < maxHearts; i++)
        {
            GameObject newHeart = Instantiate(_heartPrefab, transform);
            _hearts.Add(newHeart);
        }
    }

    public void DisplayHearts(int heart)
    {
        for (int i = 0; i < _hearts.Count; i++)
        {
            if(i < heart)
            {
                _hearts[i].SetActive(true);
            }
            else
            {
                _hearts[i].SetActive(false);
            }
        }
    }
}
