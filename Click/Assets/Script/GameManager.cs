using System.IO;//파일 불러오기
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField]
    private User user = null;
    [SerializeField]
    private Transform textPool = null;
    public Transform Pool { get { return textPool; } }
    public User CurrentUser { get { return user; } }

    public UIManager uimanager { get; private set; }
    public RandomSelect randomSelect { get; private set; }

    private long mps;
    private string Save_Path = "";
    private readonly string Save_File = "/SaveFile.txt";

    
    private void Awake()
    {
        Save_Path = Application.persistentDataPath + "/Save";
        if(!Directory.Exists(Save_Path))
        {
            Directory.CreateDirectory(Save_Path);
        }
        LoadToJson();
        uimanager = GetComponent<UIManager>();
        randomSelect = GetComponent<RandomSelect>();

        InvokeRepeating("SaveToJson", 1f, 60f);
        InvokeRepeating("EarnEnergyPerSecond", 0f, 1f);
    }
    public void EarnEnergyPerSecond()
    {
        foreach (Tree tree in user.treeList)
        {
            user.energy += tree.ePs * tree.amount;
        }
        uimanager.UpdateEnergyPanel();
    }
    private void LoadToJson()
    {
        string json = "";
        if (File.Exists(Save_Path + Save_File))
        {
            json = File.ReadAllText(Save_Path + Save_File);
            user = JsonUtility.FromJson<User>(json);
        }
        else
        {
            SaveToJson();
            LoadToJson();
        }
    }
    private void SaveToJson()
    {
        Save_Path = Application.persistentDataPath + "/Save";
        if (user == null) return;
        string json = JsonUtility.ToJson(user, true);
        File.WriteAllText(Save_Path + Save_File, json, System.Text.Encoding.UTF8);
    }
    private void OnApplicationQuit()
    {
        SaveToJson();
    }

}