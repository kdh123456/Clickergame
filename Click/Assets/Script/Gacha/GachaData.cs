using UnityEngine;
public enum GachaGrade {Legend, Rare, Normal}

[System.Serializable]
public class GachaData
{
    public string name;
    public string rankingname;
    public GachaGrade gachagrade;
    public int weight;
    public int index;
    public int amount;
    public GachaData(GachaData gachaData)
    {
        this.name = gachaData.name;
        this.rankingname = gachaData.rankingname;
        this.gachagrade = gachaData.gachagrade;
        this.weight = gachaData.weight;
        this.index = gachaData.index;
        this.amount = gachaData.amount;
    }
}
