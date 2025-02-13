using UnityEngine;
using UnityEngine.VFX;

public class BulletScript : MonoBehaviour
{
    public string spawnTag;
    public Rigidbody rb;
    bool collision=false;
    void OnCollisionEnter(Collision other)
    {
        if (!collision)
        {
            if (!other.gameObject.CompareTag(spawnTag))
            {
                //se eu colidi com algo que nao me espawnou
                gameObject.GetComponent<VisualEffect>().SendEvent("OnDeath");
                gameObject.GetComponent<VisualEffect>().SetFloat("ScaleOverride", 0f);
                Destroy(this.gameObject, 1f);
            }

            if (spawnTag == "Player" && other.gameObject.CompareTag("Enemy"))
            {
                ZinUnitScript teste;
                teste = other.gameObject.GetComponentInParent<ZinUnitScript>();
                teste.TakeDamage();
                Collide();
            }
            if (spawnTag == "Enemy" && other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<HPManagerScript>().TakeDamage();
                Collide();
            }
        }

    }

    void Collide()
    {
        rb.linearVelocity = Vector3.zero;
        collision = true;
        rb.isKinematic = true;
    }
}
