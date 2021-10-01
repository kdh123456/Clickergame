using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    private static bool singletondown = false;
    private static object locker = new object();

    public static T Instance
    {
        get
        {
            if(singletondown == true)
            {
                Debug.LogError("ΩÃ±€≈Ê ø°∑Ø");
            }
            lock(locker)
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if(instance == null)
                    {
                        instance = new GameObject(typeof(T).ToString()).AddComponent<T>();
                        DontDestroyOnLoad(instance);
                    }
                }
            }
            return instance;
        }
    }
}