using Unity.Behavior;
using UnityEngine;

public class ZinUnitScript : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject playerInstance;
    public Transform fireBoneTransform;

    public Collider localCollider;

    public GameObject _deathVFXPrefab;
    public BehaviorGraphAgent localGraph;
    public void FireEvent()
    {
        if (playerInstance == null)
        {
            Debug.LogWarning("player instance is null");
        }
        Vector3 targetDir = playerInstance.transform.position-transform.position+Vector3.down*2;

        GameObject aux = Instantiate(BulletPrefab, fireBoneTransform.position + fireBoneTransform.up, Quaternion.LookRotation(targetDir));
        aux.GetComponent<BulletScript>().spawnTag = "Enemy";
        aux.GetComponent<BulletScript>().targetTag = "Player";
        aux.GetComponent<BulletScript>().bulletVelocity = .5f;

    }

    public void TakeDamage(int damage= 0)
    {
        if (damage >= 0) {
            Animator auxAnimator = GetComponent<Animator>();
            if (auxAnimator != null) { 
                GetComponent<Animator>().enabled = false;
                localCollider.enabled = false;
            }
            if(_deathVFXPrefab)Instantiate(_deathVFXPrefab,transform.position,Quaternion.identity);
            if (localGraph != null) { localGraph.enabled = false; }
            Destroy(this.transform.gameObject, 1f);
            AudioSingleton.instance.PlaySFX(AudioSingleton.sfx.blast);
        }
    }

}
