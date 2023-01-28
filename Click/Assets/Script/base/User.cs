using System.Collections.Generic;

[System.Serializable]

public class User//스트럭트를 사용할 수 있다ㅏ. 함수를 쓸 때는 class 그냥 쓰는 거는 스트럭트 스트럭트가 더 가벼움
{
    public long energy;
    public long gold;
    public int boxcount;
    public List<CockTail> treeList = new List<CockTail>(); //개수가 정해지지 않는 배열
    public List<GachaData> gachaList = new List<GachaData>();
}
