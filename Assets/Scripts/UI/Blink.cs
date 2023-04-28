using System.Collections;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] private Renderer[] _renderers;

    public void StartBlink()
    {
        StartCoroutine(BlinkEffect());
    }

    public IEnumerator BlinkEffect()
    {
        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            for (int j = 0; j < _renderers.Length; j++)
            {
                for (int k = 0; k < _renderers[j].materials.Length; k++)
                {
                    _renderers[j].materials[k].SetColor("_EmissionColor", new Color(Mathf.Sin(i * 30) * 0.5f + 0.5f, 0, 0, 0));
                }
            }
            yield return null;
        }
    }

}
