using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject _option;
    [SerializeField]
    private GameObject _help;
    public void OnOption()
    {
        _option.gameObject.SetActive(true);
    }
    public void OnBackGame()
    {
        _option.gameObject.SetActive(false);
    }
    public void OnQuitGame()
    {
        Application.Quit();
    }
	public void OnHelp()
	{
        _help.SetActive(true);
	}
	public void OnCancelHelp()
	{
        _help.SetActive(false);
	}
}
