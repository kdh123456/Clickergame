using System.IO;//파일 불러오기
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField]
    private User user = null;
    public User CurrentUser { get { return user; } }//유저 선언

    private string SAVE_PATH = ""; //페스 선언
    private readonly string SAVE_FILENAME = "/SaveFile.txt"; //세이브 파일 이름

    public UIManager uIManager { get; private set; }

    public void EarnEnergyPerSecond()
    {
        foreach (Soldier soldier in user.soldeierList)
        {
            user.energy += soldier.ePs * soldier.amount;
        }
        uIManager.UpdateEnergyPanel();
    }
    private void Awake()
    {
        SAVE_PATH = Application.dataPath + "/Save";            //persistentDataPath:모바일
        if (!Directory.Exists(SAVE_PATH))
        {
            Directory.CreateDirectory(SAVE_PATH);
        }
        LoadFromJson();
        uIManager = GetComponent<UIManager>();


        InvokeRepeating("SaveToJson", 1f, 60f); //일정시간동안 함수반복
        InvokeRepeating("EarnEnergyPerSecond", 0f, 1f);

    }

    private void LoadFromJson()
    {
        string json = "";

        if (File.Exists(SAVE_PATH + SAVE_FILENAME))
        {
            json = File.ReadAllText(SAVE_PATH + SAVE_FILENAME);
            user = JsonUtility.FromJson<User>(json);
        }
        else
        {
            SaveToJson();
            LoadFromJson();
        }
    }
    private void SaveToJson()
    {
        SAVE_PATH = Application.dataPath + "/Save";            //persistentDataPath:모바일
        if (user == null) return;
        string json = JsonUtility.ToJson(user, true);
        File.WriteAllText(SAVE_PATH + SAVE_FILENAME, json, System.Text.Encoding.UTF8);
    }

    /*private void OnApplicationPause(bool pause) //화면이 멈출때마다
    {
        SaveToJson();
    }*/
    private void OnApplicationQuit()
    {
        SaveToJson();
    }
}