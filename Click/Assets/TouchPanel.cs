using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPanel : MonoBehaviour
{
	[SerializeField]
	private Animator[] _shakerAnimator;

	public int beckerIndex;
	public void PlusGold()
	{
		GameManager.Instance.CurrentUser.energy += 1;
		GameManager.Instance.CurrentUser.boxcount++;
		SoundManager.Instance.SetEffectSoundClip(0);
		_shakerAnimator[beckerIndex].Play("sk");

		GameObject newText;
		newText = UIPool.Instance.GetObject(PoolObjectType.Text);
		newText.transform.localScale = Vector3.one;
		newText.gameObject.SetActive(true);
		newText.GetComponent<EnergyText>().Show(1);
	}

	public void BeckerChange()
	{
		_shakerAnimator[beckerIndex].gameObject.SetActive(false);
		beckerIndex = beckerIndex++ % 2;
		_shakerAnimator[beckerIndex].gameObject.SetActive(true);
	}
}
