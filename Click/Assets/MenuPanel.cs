using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class MenuPanel : MonoBehaviour
{
	private bool _panelDown = false;
	[SerializeField]
	private RectTransform _rect;

	[SerializeField]
	private Image _menuImage;

	private Dictionary<Type, GameObject> optionObject = new Dictionary<Type, GameObject>();
	public void OnDownButtonClick() //버튼 클릭시 내려가기 올라가기
	{
		if (_panelDown == false)
		{
			_rect.DOAnchorPosY(-1300f, 1);
			_menuImage.rectTransform.DORotate(Vector3.forward * 180, 1);
		}
		else
		{
			_rect.DOAnchorPosY(32, 1);
			_menuImage.rectTransform.DORotate(Vector3.zero, 1);
		}

		_panelDown = !_panelDown;
	}

	public void AddObject(Type type,GameObject obj)
	{
		optionObject.Add(type,obj);
	}

	public void MenuOpen(Type type)
	{
		foreach(var a in optionObject)
		{
			if (a.Key != type)
				a.Value.SetActive(false);
			else
				a.Value.SetActive(true);
		}
	}
}
