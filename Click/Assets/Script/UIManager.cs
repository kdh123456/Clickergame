using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text energyText = null;
    //[SerializeField]
    //private Animator beakerAnimator = null;
    [SerializeField]
    private UpgradePanel upgradePanelTemplate = null;
    [SerializeField]
    private Button button = null;

    private RectTransform rect = null;

    private List<UpgradePanel> upgradePanelList = new List<UpgradePanel>();


    private bool upgardepaneldown = false;

    private void Awake()
    {
        rect = button.GetComponent<RectTransform>();
    }

    private void Start()
    {
        UpdateEnergyPanel();
        CreatePanels();
    }

    public void CreatePanels()
    {
        GameObject panel = null;
        UpgradePanel panelComponent = null;
        foreach (var soldier in GameManager.Instance.CurrentUser.soldeierList)
        {
            panel = Instantiate(upgradePanelTemplate.gameObject, upgradePanelTemplate.transform.parent);
            panelComponent = panel.GetComponent<UpgradePanel>();
            panelComponent.SetValue(soldier);//솔져 값대로 게임에 출력해준다.
            panel.SetActive(true);
            upgradePanelList.Add(panelComponent);
        }
    }
    public void OnClickBeaker()
    {
        GameManager.Instance.CurrentUser.energy += 1;
        //beakerAnimator.Play("click");
        UpdateEnergyPanel();
    }
    public void UpdateEnergyPanel()
    {
        energyText.text = string.Format("{0}에너지", GameManager.Instance.CurrentUser.energy);
    }

    public void Onbuttonclick()
    {
        if(upgardepaneldown == false)
        {
            rect.DOAnchorPosY(-235, 1);
            upgardepaneldown = true;
        }
        else if(upgardepaneldown == true)
        {
            rect.DOAnchorPosY(-35, 1);
            upgardepaneldown = false;
        }
    }

}
