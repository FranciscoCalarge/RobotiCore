using UnityEngine;
using UnityEngine.VFX;

public class BulletScript : MonoBehaviour
{
    public string spawnTag;
    public Rigidbody rb;
    public float bulletVelocity=0;
    bool collision=false;
/*    void OnCollisionEnter(Collision other)
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
*/
    private void OnTriggerEnter(Collider other)
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

    private void FixedUpdate()
    {
        if (Mathf.Abs(bulletVelocity) > 0)
        {
            transform.position += transform.forward * bulletVelocity;
        }
    }

    void Collide()
    {
        collision = true;
        rb.isKinematic = true;
    }
}
