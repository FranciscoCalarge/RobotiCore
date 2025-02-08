using UnityEngine;
using UnityEngine.VFX;

public class BulletScript : MonoBehaviour
{
    public string spawnTag;
    void OnCollisionEnter(Collision other)
    {

        if (!other.gameObject.CompareTag(spawnTag))
        {
            Debug.Log(other.gameObject.tag);
            Debug.Log("spawntag"+spawnTag);

            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<VisualEffect>().SendEvent("OnDeath");
            gameObject.GetComponent<VisualEffect>().SetFloat("ScaleOverride",0f);
            Destroy(this.gameObject, 1f);
            
        }
    }
}
