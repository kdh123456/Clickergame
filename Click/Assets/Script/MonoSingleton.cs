using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour//T�ڸ��� ������ �� �� �ִٴ� �� <t>��
{
    private static T instance = null;
    private static bool shuttingDown = false;
    private static object loker = new object(); // object�� ��Ʈ�� �׷��ź��� �ξ� ���� ���� �⺻
    public static T Instance
    {
        get
        {
            if (shuttingDown == true)
            {
                Debug.LogWarning("[Singleton] Instance" + "is already destroyed. returning null.");
                return null;
            }
            lock (loker)//�ڵ带 �� �� �������� ���ϰ� ���ش�.
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        instance = new GameObject(typeof(T).ToString()).AddComponent<T>();//���ο� ���ӿ�����Ʈ�� ������ְ� Ÿ�Կ��� �� ��Ʈ������ tŸ���� ��Ʈ������ �ٲٰ� �װ� �̸��� ������� �ȴ�. 
                        DontDestroyOnLoad(instance);
                    }
                }
                return instance;
            }
        }
    }

    private void OnDestroy()//�μ�������
    {
        shuttingDown = true;
    }

    private void OnApplicationQuit()//���ø����̼��� ������ ��
    {
        shuttingDown = true;
    }
}