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
        priceText.text = string.Format("{0} 에너지", soldier.price);
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
        //for문 사용해서 찾는 방법과 find로 찾는 방법이 있다.
        Soldier soldierInList = GameManager.Instance.CurrentUser.soldeierList.Find((x) => x == soldier);//x.Equal(soldier)이게 더 빠름 근데 왜 빠름?
        soldierInList.amount++;
        soldierInList.price = (long)(soldierInList.price * 1.25f);
        amountText.text = string.Format("{0}", soldierInList.amount);
        priceText.text = string.Format("{0} 에너지", soldierInList.price);
        GameManager.Instance.uIManager.UpdateEnergyPanel();
        //equals는 메서드고 메소드는 비교하고자 하는 대상의 내용자체를 비교하지만. ==연산자는 비교하고자 하는 대상의 주소값을 비교한다.
        /*
         * string a = "aaa"; 임의 주소500
         * string b = a; 임의 주소500
         * string c = new string("aaa");일때 임의주소 600
         * 모두 똑같은 값을 가지고 있지만 주소값이 다르다
         * 그렇기 때문에 b.equals(c)는 true이지만 b==c의 값은 false이다.
         */
    }
}
