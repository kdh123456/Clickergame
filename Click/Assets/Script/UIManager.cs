using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text energyText = null;
    //[SerializeField]
    //private Animator beakerAnimator = null;
    [SerializeField]
    private UpgradePanel upgradePanelTemplate = null;

    private List<UpgradePanel> upgradePanelList = new List<UpgradePanel>();

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
            panelComponent.SetValue(soldier);//���� ����� ���ӿ� ������ش�.
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
        energyText.text = string.Format("{0}������", GameManager.Instance.CurrentUser.energy);
    }

}
