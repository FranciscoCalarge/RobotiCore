using UnityEngine;
using UnityEngine.VFX;

public class BulletScript : MonoBehaviour
{
    public string spawnTag;
    public string targetTag;
    public Rigidbody rb;
    public float bulletVelocity=0;
    bool collision=false;


    private void FixedUpdate()
    {
        if (Mathf.Abs(bulletVelocity) > 0)
        {
            if (!collision) { 
                transform.position += transform.forward * bulletVelocity;
            }
        }

        RaycastHit hitInfo;
        if (Physics.SphereCast(transform.position,.5f, transform.forward, out hitInfo,.5f))
        {
            if (hitInfo.collider.CompareTag(targetTag)) {
                if (targetTag == "Enemy")
                {
                    hitInfo.collider.gameObject.GetComponentInParent<ZinUnitScript>().TakeDamage();
                }
                if (targetTag == "Player")
                {
                    Debug.Log(hitInfo.collider.gameObject);
                    HPManagerScript hpManager = hitInfo.collider.GetComponent<HPManagerScript>();
                    hpManager.TakeDamage();
                }
                Collide();
            }
            if (hitInfo.collider.CompareTag("Ground"))
            {
                Collide();
            }
        }
    }

    void Collide()
    {
        collision = true;
        rb.isKinematic = true;
        Destroy(this.gameObject);
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position+transform.forward);
    }
}
