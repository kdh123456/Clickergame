using System.Collections;
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
	public void OnDownButtonClick() //��ư Ŭ���� �������� �ö󰡱�
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
}
