using UnityEngine;
using static Unity.Burst.Intrinsics.X86;

public class ZinUnitScript : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject playerInstance;
    public Transform fireBoneTransform;
    public void FireEvent()
    {
        playerInstance = MovementScript.Instance.gameObject;
        Vector3 targetDir = playerInstance.transform.position-transform.position;

        GameObject aux = Instantiate(BulletPrefab, fireBoneTransform.position,Quaternion.identity);
        aux.GetComponent<Rigidbody>().linearVelocity = targetDir *5;
        aux.GetComponent<BulletScript>().spawnTag = transform.gameObject.tag;

    }

}
