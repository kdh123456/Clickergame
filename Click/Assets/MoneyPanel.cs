using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyPanel : MonoBehaviour
{
    [SerializeField]
    private Text _moneyText;
    [SerializeField]
    private Text _goldText;
    public void UpdateEnergyPanel()
    {
        _moneyText.text = string.Format("{0} ¿ø", GameManager.Instance.CurrentUser.energy);
    }
    public void UpdateGoldPanel()
    {
        _goldText.text = string.Format("{0} °³", GameManager.Instance.CurrentUser.gold);
    }
}
