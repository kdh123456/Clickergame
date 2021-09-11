using System.IO;//���� �ҷ�����
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField]
    private User user = null;
    public User CurrentUser { get { return user; } }//���� ����

    private string SAVE_PATH = ""; //�佺 ����
    private readonly string SAVE_FILENAME = "/SaveFile.txt"; //���̺� ���� �̸�

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
        SAVE_PATH = Application.dataPath + "/Save";            //persistentDataPath:�����
        if (!Directory.Exists(SAVE_PATH))
        {
            Directory.CreateDirectory(SAVE_PATH);
        }
        LoadFromJson();
        uIManager = GetComponent<UIManager>();


        InvokeRepeating("SaveToJson", 1f, 60f); //�����ð����� �Լ��ݺ�
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
        SAVE_PATH = Application.dataPath + "/Save";            //persistentDataPath:�����
        if (user == null) return;
        string json = JsonUtility.ToJson(user, true);
        File.WriteAllText(SAVE_PATH + SAVE_FILENAME, json, System.Text.Encoding.UTF8);
    }

    /*private void OnApplicationPause(bool pause) //ȭ���� ���⶧����
    {
        SaveToJson();
    }*/
    private void OnApplicationQuit()
    {
        SaveToJson();
    }
}