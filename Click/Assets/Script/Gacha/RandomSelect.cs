using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSelect : MonoSingleton<RandomSelect>
{
    public int i = 0;
    public GameObject gachabackground;
    [SerializeField]
    private Button Gachabutton;
    [SerializeField]
    private Button Gachabutton10;
    [SerializeField]
    private Button Gachabutton100;

    [Header("가챠 가격")]
    [SerializeField]
    private int Gachaprice = 10;

    public List<GachaData> desk = new List<GachaData>();
    public int total = 0;
    //public List<GachaData> result = new List<GachaData>();

    [SerializeField]
    private Transform parent;
    [SerializeField]
    private GameObject cardprefab;
    private User user;


    public void ResultSelect(int i)
    {
        GameManager.Instance.CurrentUser.gold -= 10;

        //result.Add(desk[RandomGacha().index]);
        GachaData gachaData;
        gachaData = RandomGacha();
        GameManager.Instance.CurrentUser.gachaList.Add(gachaData);
        GachaUI gachaUI = Instantiate(cardprefab, parent).GetComponent<GachaUI>();
        gachaUI.GachaUISet(gachaData);
    }
    public GachaData RandomGacha()
    {
        int weight = 0;
        int selectNum = 0;
        selectNum = Mathf.RoundToInt(total * Random.Range(0.0f, 1.0f));
        for (int i = 0; i < desk.Count; i++)
        {
            weight += desk[i].weight;
            if (selectNum <= weight)
            {
                GachaData temp = new GachaData(desk[i]);
                temp.amount++;
                return temp;
            }
        }
        return null;
    }
    private void Start()
    {
        for (int i = 0; i < desk.Count; i++)
        {
            total += desk[i].weight;
        }
    }
    private void Update()
    {
        Gachack();
    }
    private void Gachack()
    {
        if (Gachaprice <= GameManager.Instance.CurrentUser.gold)
        {
            Gachabutton.enabled = true;
            if (GameManager.Instance.CurrentUser.gold >= Gachaprice * 10)
            {
                Gachabutton10.enabled = true;
            }
            else if (GameManager.Instance.CurrentUser.gold < Gachaprice * 10)
            {
                Gachabutton10.enabled = false;
            }
            if (GameManager.Instance.CurrentUser.gold >= Gachaprice * 100)
            {
                Gachabutton100.enabled = true;
            }
            else if (GameManager.Instance.CurrentUser.gold < Gachaprice * 100)
            {
                Gachabutton100.enabled = false;
            }
        }
        else if (Gachaprice > GameManager.Instance.CurrentUser.gold)
        {
            Gachabutton.enabled = false;
        }
    }
    public void OnGachabutton()
    {
        gachabackground.SetActive(true);
        ResultSelect(0);
        Gachaamountck();
    }
    public void OnGachabutton10()
    {
        gachabackground.SetActive(true);
        for (int i = 0; i < 10; i++)
        {
            ResultSelect(i);
            Gachaamountck();
            /*if (i == 0)
            {
                continue;
            }
            gachabackground.transform.GetChild(i).gameObject.SetActive(false);*/
        }
    }

    public void OnGachabutton100()
    {
        gachabackground.SetActive(true);
        for (int i = 0; i < 100; i++)
        {
            ResultSelect(i);
            Gachaamountck();
            /*if (i == 0)
            {
                continue;
            }
            gachabackground.transform.GetChild(i).gameObject.SetActive(false);*/
        }
    }
    public void Gachaamountck()
    {
        foreach (var gc in GameManager.Instance.CurrentUser.gachaList)
        {
            if (gc.index == 0)
            {
                if (gc.amount > 0)
                {
                    GameManager.Instance.CurrentUser.treeList[0].ePs = GameManager.Instance.CurrentUser.treeList[0].ePs + 10;
                    gc.amount = 0;
                }
            }
            else if (gc.index == 1)
            {
                if (gc.amount > 0)
                {
                    GameManager.Instance.CurrentUser.treeList[0].ePs = GameManager.Instance.CurrentUser.treeList[0].ePs + 20;
                    gc.amount = 0;
                }
            }
            else if (gc.index == 2)
            {
                if (gc.amount > 0)
                {
                    GameManager.Instance.CurrentUser.treeList[0].ePs = GameManager.Instance.CurrentUser.treeList[0].ePs + 30;
                    gc.amount = 0;
                }
            }
        }
    }
}
