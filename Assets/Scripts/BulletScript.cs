using UnityEngine;
using UnityEngine.VFX;

public class BulletScript : MonoBehaviour
{
    public string spawnTag;
    public Rigidbody rb;
    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag(spawnTag))
        {
            //se eu colidi com algo que nao me espawnou
            gameObject.GetComponent<VisualEffect>().SendEvent("OnDeath");
            gameObject.GetComponent<VisualEffect>().SetFloat("ScaleOverride",0f);
            Destroy(this.gameObject, 1f);
            
        }

        if (spawnTag=="Player"&&other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<ZinUnitScript>().TakeDamage();
            this.enabled = false;
            rb.isKinematic = true;

        }
        if (spawnTag == "Enemy" && other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HPManagerScript>().TakeDamage();
            this.enabled = false;
            rb.isKinematic = true;

        }


    }
}
