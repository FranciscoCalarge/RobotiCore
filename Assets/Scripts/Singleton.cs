using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour
{
    private static Singleton<T> instance { get; set; }
    public static Singleton<T> Instance
    {
        get
        {
            if(instance == null){
                instance=FindAnyObjectByType<Singleton<T>>();
                if (instance == null)
                {
                    instance=new GameObject().AddComponent<Singleton<T>>();
                    instance.name = typeof(Singleton<T>).Name;
                }
            }
            return instance;
        }
    }

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
    }
}
