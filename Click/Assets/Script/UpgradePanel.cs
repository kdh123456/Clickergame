using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField]
    private Image treeimage = null;

    [SerializeField]
    private Text treeNameText = null;

    [SerializeField]
    private Text priceText = null;

    [SerializeField]
    private Text amountText = null;

    [SerializeField]
    private Sprite[] treeSprite = null;

    private CockTail cockTail = null;

    public void SetValue(CockTail tree)
    {
        this.cockTail = tree;
        UpdateUI();
    }

    public void UpdateUI()
    {
        treeimage.sprite = treeSprite[cockTail.imageNumber];
        treeNameText.text = cockTail.name;
        priceText.text = string.Format("¿ø°¡ {0}", cockTail.price);
        amountText.text = string.Format("¼÷·Ãµµ {0}", GameManager.Instance.CockTail.cockList[cockTail.imageNumber].amount);
    }

    public void OnClickPurchase()
    {
        if (GameManager.Instance.UserData.energy < cockTail.price)
        {
            return;
        }
        GameManager.Instance.UserData.energy -= cockTail.price;
        GameManager.Instance.CockTail.cockList[cockTail.imageNumber].amount++;
        cockTail.price = (long)(cockTail.price * 1.25f);
        UpdateUI();
    }
}
