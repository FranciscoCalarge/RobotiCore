using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public string spawnTag;
    void OnCollisionEnter(Collision other)
    {

        if (!other.gameObject.CompareTag(spawnTag))
        {
            Debug.Log(other.gameObject.tag);
            Debug.Log("spawntag"+spawnTag);

            Destroy(this.gameObject);
            
        }
    }
}
