using System.Collections.Generic;

[System.Serializable]

public class User//��Ʈ��Ʈ�� ����� �� �ִ٤�. �Լ��� �� ���� class �׳� ���� �Ŵ� ��Ʈ��Ʈ ��Ʈ��Ʈ�� �� ������
{
    public long energy;
    public long gold;
    public int boxcount;
    public List<CockTail> treeList = new List<CockTail>(); //������ �������� �ʴ� �迭
    public List<GachaData> gachaList = new List<GachaData>();
}
