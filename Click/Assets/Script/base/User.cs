using System.Collections.Generic;

[System.Serializable]

public class User//��Ʈ��Ʈ�� ����� �� �ִ٤�. �Լ��� �� ���� class �׳� ���� �Ŵ� ��Ʈ��Ʈ ��Ʈ��Ʈ�� �� ������
{
    public string nickname;
    public long energy;
    public List<Soldier> soldeierList = new List<Soldier>(); //������ �������� �ʴ� �迭
}
