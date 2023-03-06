using System;
using System.Collections.Generic;

[System.Serializable]

public class User
{
    public long energy;
    public long gold;
    public int boxcount;
}

[Serializable]
public class CockTailData
{
    public List<CockTail> cockList = new List<CockTail>();
}

[Serializable]
public class InventoryData
{
    public List<GachaData> gachaList = new List<GachaData>();
}
