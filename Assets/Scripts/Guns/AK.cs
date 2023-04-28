using TMPro;
using UnityEngine;

public class AK : Gun
{
    [Header("AK")]
    [SerializeField] private int _numOfBullets;
    [SerializeField] private TextMeshProUGUI _bulletsText;
    [SerializeField] private PlayerArmory _playerArmory;

    public override void Shot()
    {
        base.Shot();
        _numOfBullets -= 1;
        UpdateText();
        if(_numOfBullets == 0)
        {
            _playerArmory.TakeGunByIndex(0);
        }
    }

    public override void Activate()
    {
        base.Activate();
        _bulletsText.enabled = true;
        UpdateText();
    }
    public override void Deactivate()
    {
        base.Deactivate();
        _bulletsText.enabled = false;
    }

    private void UpdateText()
    {
        _bulletsText.text = "Пули: " + _numOfBullets.ToString();
    }

    public override void AddBullets(int numOfBullets)
    {
        base.AddBullets(numOfBullets);
        _numOfBullets += numOfBullets;
        UpdateText();
        _playerArmory.TakeGunByIndex(1);
    }
}
