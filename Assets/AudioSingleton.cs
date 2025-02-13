using UnityEngine;

public class AudioSingleton : Singleton<AudioSingleton>
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this);
        GetComponent<AudioSource>().Play();
    }

}
