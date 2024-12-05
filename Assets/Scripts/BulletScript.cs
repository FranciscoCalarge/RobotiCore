using UnityEngine;

public class BulletScript : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
