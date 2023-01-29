using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject help = null;
    [SerializeField]
    private GameObject Startsceen = null;
    [SerializeField]
    private GameObject updatesoon = null;
    [SerializeField]
    private Image goldbar = null;
    [SerializeField]
    private Text energyText = null;
    [SerializeField]
    private Text goldText = null;
    [SerializeField]
    private Animator shakeranimator = null;
    [SerializeField]
    private Animator gshakeranimator = null;
    [SerializeField]
    private UpgradePanel upgradePanelTemplate = null;
    [SerializeField]
    private EnergyText energyTextTemplate = null;
    [SerializeField]
    private GachaData gachadata = null;
    [SerializeField]
    private Image gskimage = null;
    [SerializeField]
    private Image feverimage = null;
    [SerializeField]
    private Button downbutton = null;
    [SerializeField]
    private GameObject cocktailbutton = null;
    [SerializeField]
    private GameObject drawbutton = null;
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

    private float t = 0f;

    private bool goldckb2 = false;
    private bool goldckb = false;
    private bool timestart = true;

    private int Fever = 1;
    private int Count = 0;

    private RectTransform rect = null;

    private List<UpgradePanel> upgradePanelList = new List<UpgradePanel>();

    public GachaData GachaData { get { return gachadata; } }

    public void Awake()
    {
        CreatePanels();
    }
    private int a;
    public void Update()
    {
        a = GameManager.Instance.CurrentUser.boxcount % 100;
    }


    public void CreatePanels()
    {
        GameObject panel = null;
        UpgradePanel panelComponent = null;
        foreach (var tree in GameManager.Instance.CurrentUser.treeList)
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
