using UnityEngine;
using static Unity.Burst.Intrinsics.X86;

public class ZinUnitScript : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject playerInstance;
    public Transform fireBoneTransform;

    public GameObject _deathVFXPrefab;
    public void FireEvent()
    {
        playerInstance = MovementScript.Instance.gameObject;
        Vector3 targetDir = playerInstance.transform.position-transform.position;

        GameObject aux = Instantiate(BulletPrefab, fireBoneTransform.position,Quaternion.identity);
        aux.GetComponent<Rigidbody>().linearVelocity = targetDir *3;
        aux.GetComponent<BulletScript>().spawnTag = transform.gameObject.tag;

    }

    public void TakeDamage(int damage= 0)
    {
        if (damage >= 0) {
            GetComponent<Animator>().enabled = false;
            if(_deathVFXPrefab)Instantiate(_deathVFXPrefab,transform.position,Quaternion.identity);
            Destroy(this.transform.parent.gameObject, 1f);
        }
    }

}
