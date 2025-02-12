using UnityEngine;
using UnityEngine.VFX;

public class BulletScript : MonoBehaviour
{
    public string spawnTag;
    void OnCollisionEnter(Collision other)
    {

        if (!other.gameObject.CompareTag(spawnTag))
        {
            Debug.Log("spawntag"+spawnTag);

            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<VisualEffect>().SendEvent("OnDeath");
            gameObject.GetComponent<VisualEffect>().SetFloat("ScaleOverride",0f);
            Destroy(this.gameObject, 1f);
            
        }

        if (spawnTag=="Player"&&other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<ZinUnitScript>().TakeDamage();
        }
        if (spawnTag == "Enemy" && other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HPManagerScript>().TakeDamage();
        }

    }
}
