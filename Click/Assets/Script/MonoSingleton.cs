using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour//T자리에 뭐든지 들어갈 수 있다는 뜻 <t>가
{
    private static T instance = null;
    private static bool shuttingDown = false;
    private static object loker = new object(); // object는 인트나 그런거보다 훨씬 작은 개념 기본
    public static T Instance
    {
        get
        {
            if (shuttingDown == true)
            {
                Debug.LogWarning("[Singleton] Instance" + "is already destroyed. returning null.");
                return null;
            }
            lock (loker)//코드를 두 번 실행하지 못하게 해준다.
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        instance = new GameObject(typeof(T).ToString()).AddComponent<T>();//새로운 게임오브젝트를 만들어주고 타입오프 투 스트링으로 t타입을 스트링으로 바꾸고 그걸 이름을 갖고오게 된다. 
                        DontDestroyOnLoad(instance);
                    }
                }
                return instance;
            }
        }
    }

    private void OnDestroy()//부서졌을때
    {
        shuttingDown = true;
    }

    private void OnApplicationQuit()//에플리케이션이 꺼졌을 때
    {
        shuttingDown = true;
    }
}