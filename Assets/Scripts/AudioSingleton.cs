using UnityEngine;

public class AudioSingleton : MonoBehaviour
{
    public static AudioSingleton instance { get; set; }

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource BoostSource;

    public AudioClip RoboticoreOST;
    public AudioClip passosSFX;
    public AudioClip boostSFX;
    public AudioClip PlayerFireSFX;
    public AudioClip enemyFireSFX;
    public AudioClip BlastSFX;
    public AudioClip CoreSFX;

    public enum sfx
    {
        None = 0,
        passos = 1,
        boost = 2,
        playerfire = 3,
        enemyfire = 4,
        blast = 5,
        core = 6,
    }

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

    }

    private void OnLevelWasLoaded(int level)
    {
        setBoostVolume(0f);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this);
        musicSource.clip = RoboticoreOST;
        musicSource.Play();
        BoostSource.clip = boostSFX;
        BoostSource.Play();
    }

    public void PlaySFX(sfx SFXEnum)
    {
        switch (SFXEnum)
        {
            case sfx.passos:
                SFXSource.PlayOneShot(passosSFX);
                break;
            case sfx.boost:
                SFXSource.PlayOneShot(boostSFX);
                break;
            case sfx.playerfire:
                SFXSource.PlayOneShot(PlayerFireSFX);
                break;
            case sfx.enemyfire:
                SFXSource.PlayOneShot(enemyFireSFX);
                break;
            case sfx.blast:
                SFXSource.PlayOneShot(BlastSFX);
                break;
            case sfx.core:
                SFXSource.PlayOneShot(CoreSFX);
                break;
            default:
                break;
        }
    }

    public void setBoostVolume(float v)
    {
        BoostSource.volume = v;
    }
}
