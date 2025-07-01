using UnityEngine;

public class PlayAnimationOnTriggerScript : MonoBehaviour
{
    public Animation animation;
    public Collider localCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animation.Play();
            localCollider.enabled = false;
            AudioSingleton.instance.PlaySFX(AudioSingleton.sfx.core);
        }
    }
}
