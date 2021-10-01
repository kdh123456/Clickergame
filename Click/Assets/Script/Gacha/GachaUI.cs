using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaUI : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites = null;

    public GameObject gj = null;
    public Image bi;
    public Image gi;
    public Text gn;
    public Text gr;
    private RandomSelect randomSelect;
    public void Start()
    {
        randomSelect = FindObjectOfType<RandomSelect>();
    }
    public void GachaUISet(GachaData gachaData)
    {
        gi.sprite = sprites[gachaData.index];
        gn.text = gachaData.name;
        gr.text = gachaData.rankingname;
        bi.color = Color.black;
    }
    public void OnClickClose()
    {
        randomSelect.i = this.transform.parent.childCount - 1;
        OnClickBackground();
        randomSelect.i = 0;
    }
    public void OnClickBackground()
    {
        randomSelect.i++;
        if (this.transform.parent.childCount == randomSelect.i)
        {
            randomSelect.gachabackground.SetActive(false);
            this.transform.parent.DetachChildren();
            Destroy(gameObject);//나중에 풀을 어케 저케 해주자
            randomSelect.i = 0;
        }
        gj.SetActive(false);
    }
}
