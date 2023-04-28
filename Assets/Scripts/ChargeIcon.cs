using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChargeIcon : MonoBehaviour
{
    [SerializeField] private Image _bg;
    [SerializeField] private Image _foreground;
    [SerializeField] private TextMeshProUGUI _timerText;

    public void StartCharge()
    {
        _bg.color = new Color(1f, 1f, 1f, 0.2f);
        _foreground.enabled = true;
        _timerText.enabled= true;
    }

    public void StopCharge()
    {
        _bg.color = new Color(1f, 1f, 1f, 1f);
        _foreground.enabled = false;
        _timerText.enabled = false;
    }

    public void SetChargeValue(float currentCharge, float maxCharge)
    {
        _foreground.fillAmount = currentCharge / maxCharge;
        _timerText.text = Mathf.Ceil(maxCharge - currentCharge).ToString();
    }

}
