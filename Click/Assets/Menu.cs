using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
	[SerializeField]
	private GameObject obj;

	protected MenuPanel _menuPanel;

	private void Start()
	{
		_menuPanel = this.GetComponentInParent<MenuPanel>();
		_menuPanel.AddObject(this.GetType(), obj);
	}

	public void Open()
	{
		_menuPanel.MenuOpen(this.GetType());
	}
}
