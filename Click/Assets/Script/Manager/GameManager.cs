using System.IO;//파일 불러오기
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private User _user => DataManager.Instance.CurrentUser;
    private InventoryData _inven => DataManager.Instance.CurrentInvenData;
    private CockTailData _cockTail => DataManager.Instance.CurrentCockTailData;
    public User UserData => _user;
    public InventoryData InvenData => _inven;
    public CockTailData CockTail => _cockTail;

    [SerializeField]
    private Transform textPool = null;
    public Transform Pool { get { return textPool; } }
    public UIManager uimanager { get; private set; }
    public RandomSelect randomSelect { get; private set; }

    private long mps;
    
    private void Awake()
    {
        uimanager = GetComponent<UIManager>();
        randomSelect = GetComponent<RandomSelect>();
        InvokeRepeating("EarnEnergyPerSecond", 0f, 1f);
    }
    public void EarnEnergyPerSecond()
    {
        foreach (CockTail tree in _cockTail.cockList)
        {
            _user.energy += tree.ePs * tree.amount;
        }
        //uimanager.UpdateEnergyPanel();
    }
}