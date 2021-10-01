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

    private float t = 0f;

    private bool goldckb2 = false;
    private bool goldckb = false;
    private bool Countonoff = true;
    private bool timestart = true;
    private bool upgardepaneldown = false;

    private int Fever = 1;
    private int Count = 0;

    private RectTransform rect = null;

    private List<UpgradePanel> upgradePanelList = new List<UpgradePanel>();

    public GachaData GachaData { get { return gachadata; } }

    public void Awake()
    {
        rect = downbutton.GetComponent<RectTransform>();
        UpdateEnergyPanel();
        CreatePanels();
    }
    private int a;
    public void Update()
    {
        a = GameManager.Instance.CurrentUser.boxcount % 100;
        goldck();
        Fevertimeck();
        UpdateGoldPanel();
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

    public void UpdateGoldPanel()
    {
        goldText.text = string.Format("{0} 개", GameManager.Instance.CurrentUser.gold);
    }
    public void UpdateEnergyPanel()
    {
        energyText.text = string.Format("{0} 원", GameManager.Instance.CurrentUser.energy);
    }

    public void OnClickBeaker()
    {
        GameManager.Instance.CurrentUser.energy += 1 * Fever;
        GameManager.Instance.CurrentUser.boxcount++;
        SoundManager.Instance.SetEffectSoundClip(0);
        shakeranimator.Play("sk");
        if (Countonoff == true)
        {
            Count++;
        }
        else if (Countonoff == false)
        {
            gshakeranimator.Play("sk");
        }

        EnergyText newText = null;

        if (GameManager.Instance.Pool.childCount > 0)
        {
            newText = GameManager.Instance.Pool.GetChild(0).GetComponent<EnergyText>();
            newText.transform.SetParent(GameManager.Instance.Pool.parent);
        }
        else
        {
            newText = Instantiate(energyTextTemplate, GameManager.Instance.Pool.parent).GetComponent<EnergyText>();
        }
        newText.transform.localPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newText.gameObject.SetActive(true);
        newText.Show(1);
        UpdateEnergyPanel();
    }
    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //골드 또는 다른거 추가 박스 코드


    public void Onmoneybox()
    {
        GameManager.Instance.CurrentUser.energy += GameManager.Instance.CurrentUser.energy * 2;
        moneyscreen.SetActive(false);
        UpdateEnergyPanel();
    }

    public void Ongoldbox()
    {
        GameManager.Instance.CurrentUser.gold += 10;
        goldscreen.SetActive(false);
        UpdateGoldPanel();

    }

    private void goldormoneybox()
    {
        int a;
        a = Random.Range(0, 3);
        switch (a)
        {
            case 1:
                goldscreen.SetActive(true);
                break;
            case 2:
                moneyscreen.SetActive(true);
                //돈
                break;
        }

    }

    private void goldck()
    {
        if (GameManager.Instance.CurrentUser.energy == 0)
        {
            goldckb = false;
        }
        else
        {
            goldckb = true;
        }
        if (a == 0 && goldckb == true)
        {
            if (goldckb2 == false && !PlayerPrefs.HasKey("one"))
            {
                PlayerPrefs.SetInt("one", 1);
                goldormoneybox();
                GameManager.Instance.CurrentUser.boxcount = 0;
                goldckb2 = true;
            }
        }
        else
        {
            PlayerPrefs.DeleteAll();
            goldckb2 = false;
        }
    }

    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //피버 타임용 코드

    public void OnClickMoneysk() //피버 타임 코드
    {
        if (Count >= 100)
        {
            Countonoff = false;
            timestart = false;
            gskimage.gameObject.SetActive(false);
            feverimage.gameObject.SetActive(true);
            Fever = 3;
        }
    }
    private void Fevertimeck()
    {
        if (Count >= 100)
        {
            goldbar.gameObject.SetActive(true);
        }
        else
        {
            goldbar.gameObject.SetActive(false);
        }
        if (timestart == false)
        {
            t += Time.deltaTime;
            Debug.Log(t);
            if (t >= 2f)
            {
                timestart = true;
                t = 0f;
                Count = 0;
                Countonoff = true;
                Fever = 1;
                gskimage.gameObject.SetActive(true);
                feverimage.gameObject.SetActive(false);
            }
        }
    }



    //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //버튼 조작

    public void Ondownbuttonclick() //버튼 클릭시 내려가기 올라가기
    {
        if (upgardepaneldown == false)
        {
            rect.DOAnchorPosY(-1300f, 1);
            upgardepaneldown = true;
        }
        else if (upgardepaneldown == true)
        {
            rect.DOAnchorPosY(113, 1);
            upgardepaneldown = false;
        }
    }
    public void Onillustratedbookbutton()
    {
        cocktailbutton.SetActive(false);
        illustratedbookbutton.SetActive(true);
        drawbutton.SetActive(false);
    }

    public void Oncocktailbutton()
    {
        cocktailbutton.SetActive(true);
        illustratedbookbutton.SetActive(false);
        drawbutton.SetActive(false);
    }

    public void Ondrawbutton()
    {
        cocktailbutton.SetActive(false);
        illustratedbookbutton.SetActive(false);
        drawbutton.SetActive(true);
    }

    public void OnrecipeButton()
    {
        updatesoon.SetActive(true);
    }
    public void OnrecipeOutButton()
    {
        updatesoon.SetActive(false);
    }

    public void OnOption()
    {
        option.gameObject.SetActive(true);
    }
    public void OnBackGame()
    {
        option.gameObject.SetActive(false);
    }
    public void OnQuitGame()
    {
        Application.Quit();
    }
    public void OnHelp()
    {
        help.SetActive(true);
    }
    public void OnCancelHelp()
    {
        help.SetActive(false);
    }
    public void OnStart()
    {
        Startsceen.SetActive(false);
    }
}
