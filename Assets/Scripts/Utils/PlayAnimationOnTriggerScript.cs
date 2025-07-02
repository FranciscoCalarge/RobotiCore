using UnityEngine;

public class PlayAnimationOnTriggerScript : MonoBehaviour
{
    public Animation animation;
    public Collider localCollider;
    public bool iscore = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animation.Play();
            localCollider.enabled = false;
            if (iscore) { 
                AudioSingleton.instance.PlaySFX(AudioSingleton.sfx.core);
            }
            else
            {
                Destroy(gameObject,2f);
            }
        }
    }
}
