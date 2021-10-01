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

    private Tree tree = null;

    public void SetValue(Tree tree)
    {
        this.tree = tree;
        UpdateUI();
    }

    public void UpdateUI()
    {
        treeimage.sprite = treeSprite[tree.imageNumber];
        treeNameText.text = tree.name;
        priceText.text = string.Format("¿ø°¡ {0}", tree.price);
        amountText.text = string.Format("¼÷·Ãµµ {0}", GameManager.Instance.CurrentUser.treeList[tree.imageNumber].amount);
    }

    public void OnClickPurchase()
    {
        if (GameManager.Instance.CurrentUser.energy < tree.price)
        {
            return;
        }
        GameManager.Instance.CurrentUser.energy -= tree.price;
        GameManager.Instance.CurrentUser.treeList[tree.imageNumber].amount++;
        tree.price = (long)(tree.price * 1.25f);
        UpdateUI();
        GameManager.Instance.uimanager.UpdateEnergyPanel();
    }
}
