using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{
	[SerializeField]
	private User user = new User();
	[SerializeField]
	private CockTailData cockTail = new CockTailData();
	[SerializeField]
	private InventoryData invenData = new InventoryData();
	public User CurrentUser { get { return user; } }
	public CockTailData CurrentCockTailData { get { return cockTail; } }
	public InventoryData CurrentInvenData { get { return invenData; } }

	private string Save_Path = "";
	private readonly string User_Save_File = "/User_SaveFile.txt";
	private readonly string CockTailData_Save_File = "/CockTailData_SaveFile.txt";
	private readonly string InvenData_SaveFile = "/GachaData_SaveFile.txt";

	private void Awake()
	{
		Init();
	}

	private void Start()
	{
		InitData();
		InvokeRepeating("SaveToJson", 1f, 60f);
	}

	private void Init()
	{
		Save_Path = Application.persistentDataPath + "/Save";
		if (!Directory.Exists(Save_Path))
		{
			Directory.CreateDirectory(Save_Path);
		}
	}

	private void InitData()
	{
		LoadToJson(User_Save_File, ref user);
		LoadToJson(CockTailData_Save_File, ref cockTail);
		LoadToJson(InvenData_SaveFile, ref invenData);
	}

	private void LoadToJson<T>(string name, ref T realData)
	{
		string json = "";
		if (File.Exists(Save_Path + name))
		{
			json = File.ReadAllText(Save_Path + name);
			realData = JsonUtility.FromJson<T>(json);
		}
		else
		{
			SaveToJson<T>(name, ref realData);
			LoadToJson<T>(name,ref realData);
		}
	}

	private void SaveToJson<T>(string name, ref T realData)
	{
		Debug.Log(Application.persistentDataPath);
		Save_Path = Application.persistentDataPath + "/Save";
		if (realData == null) return;
		string json = JsonUtility.ToJson(realData, true);
		File.WriteAllText(Save_Path + name, json, System.Text.Encoding.UTF8);
	}

	private void OnQuit()
	{
		SaveToJson(User_Save_File, ref user);
		SaveToJson(CockTailData_Save_File, ref cockTail);
	}

	private void OnApplicationQuit()
	{
		OnQuit();
	}
}
