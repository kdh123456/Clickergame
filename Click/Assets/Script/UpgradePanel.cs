using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField]
    private Image soldierImage = null;

    [SerializeField]
    private Text soldierNameText = null;

    [SerializeField]
    private Text priceText = null;

    [SerializeField]
    private Text amountText = null;

    [SerializeField]
    private Button purchaseButton = null;

    private Soldier soldier = null;

    public void SetValue(Soldier soldier)
    {
        soldierNameText.text = soldier.name;
        priceText.text = string.Format("{0} ������", soldier.price);
        amountText.text = string.Format("{0}", soldier.amount);
        this.soldier = soldier;
    }

    public void OnClickPurchase()
    {
        if (GameManager.Instance.CurrentUser.energy < soldier.price)
        {
            return;
        }
        GameManager.Instance.CurrentUser.energy -= soldier.price;
        //for�� ����ؼ� ã�� ����� find�� ã�� ����� �ִ�.
        Soldier soldierInList = GameManager.Instance.CurrentUser.soldeierList.Find((x) => x == soldier);//x.Equal(soldier)�̰� �� ���� �ٵ� �� ����?
        soldierInList.amount++;
        soldierInList.price = (long)(soldierInList.price * 1.25f);
        amountText.text = string.Format("{0}", soldierInList.amount);
        priceText.text = string.Format("{0} ������", soldierInList.price);
        GameManager.Instance.uIManager.UpdateEnergyPanel();
        //equals�� �޼���� �޼ҵ�� ���ϰ��� �ϴ� ����� ������ü�� ��������. ==�����ڴ� ���ϰ��� �ϴ� ����� �ּҰ��� ���Ѵ�.
        /*
         * string a = "aaa"; ���� �ּ�500
         * string b = a; ���� �ּ�500
         * string c = new string("aaa");�϶� �����ּ� 600
         * ��� �Ȱ��� ���� ������ ������ �ּҰ��� �ٸ���
         * �׷��� ������ b.equals(c)�� true������ b==c�� ���� false�̴�.
         */
    }
}