using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DamageScreen : MonoBehaviour
{
    [SerializeField] private Image _damageImage;
    
    public void StartDamageEffect()
    {
        StartCoroutine(ShowDamageEffect());
    }


    public IEnumerator ShowDamageEffect()
    {
        _damageImage.enabled = true;

        for (float i = 1; i > 0f; i -= Time.deltaTime * 2f)
        {
            _damageImage.color = new Color(1, 0, 0, i);
            yield return null;
        }
        _damageImage.enabled = false;
    }
}
