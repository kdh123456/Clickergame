using System.Collections.Generic;

[System.Serializable]

public class User//��Ʈ��Ʈ�� ����� �� �ִ٤�. �Լ��� �� ���� class �׳� ���� �Ŵ� ��Ʈ��Ʈ ��Ʈ��Ʈ�� �� ������
{
    public string nickname;
    public long energy;
    public long gold;
    public int boxcount;
    public List<Tree> treeList = new List<Tree>(); //������ �������� �ʴ� �迭
    public List<GachaData> gachaList = new List<GachaData>();
}
