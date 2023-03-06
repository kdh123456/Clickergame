using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Startsceen = null;
    [SerializeField]
    private GameObject updatesoon = null;
    [SerializeField]
    private UpgradePanel upgradePanelTemplate = null;
    [SerializeField]
    private GachaData gachadata = null;
    [SerializeField]
    private GameObject cocktailbutton = null;
    [SerializeField]
    private GameObject illustratedbookbutton = null;
    [SerializeField]
    private GameObject goldscreen = null;
    [SerializeField]
    private GameObject moneyscreen = null;
    [SerializeField]
    private Image option = null;
    [SerializeField]
    private GameObject textPool = null;

    private List<UpgradePanel> upgradePanelList = new List<UpgradePanel>();

    public GachaData GachaData { get { return gachadata; } }

    public void Awake()
    {
        //CreatePanels();
    }
    private int a;
    public void Update()
    {
        a = GameManager.Instance.UserData.boxcount % 100;
    }


    public void CreatePanels()
    {
        GameObject panel = null;
        UpgradePanel panelComponent = null;
        foreach (var tree in GameManager.Instance.CockTail.cockList)
        {
            panel = Instantiate(upgradePanelTemplate.gameObject, upgradePanelTemplate.transform.parent);
            panelComponent = panel.GetComponent<UpgradePanel>();
            panelComponent.SetValue(tree);
            panel.SetActive(true);
            upgradePanelList.Add(panelComponent);
        }
    }
    public void OnStart()
    {
        Startsceen.SetActive(false);
    }
}
