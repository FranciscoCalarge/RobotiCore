using UnityEditor.PackageManager;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Transform childCanvas;
    public int resolution=4;
    public float scale = 2f;
    public Transform closestEnemy;
    public MeshRenderer AimObject;
    [SerializeField] GameObject BulletPrefab;
    public LayerMask EnemyLayer;

    public bool showGizmos;



    // Update is called once per frame
    void FixedUpdate()
    {
        GridCast();
        if(closestEnemy != null)
        {
            AimObject.enabled = true;
            AimObject.transform.position = closestEnemy.position;
        }
        else
        {
            AimObject.enabled = false;
        }

        if(closestEnemy != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GameObject auxBullet = Instantiate(BulletPrefab, transform.position+transform.up, Quaternion.LookRotation(closestEnemy.transform.position-transform.position));
                auxBullet.GetComponent<BulletScript>().spawnTag = "Player";
                auxBullet.GetComponent<BulletScript>().targetTag = "Enemy";
                auxBullet.GetComponent<BulletScript>().bulletVelocity = .5f;

            }
        }
    }

    void GridCast()
    {
        //começando o gridcast precisamos saber qual será o trasform mirado neste tick
        Transform gridCastTransform = null;
        bool maintainClosest = false;
        for (int i = 0; i < resolution; i++)
        {
            for (int j = 0; j < resolution; j++)
            {
                RaycastHit hitInfo = new RaycastHit();
                Physics.Linecast(transform.position, getRayTargetPosition(i, j), out hitInfo, EnemyLayer);
                if (hitInfo.rigidbody != null)
                {
                    if (!hitInfo.collider.CompareTag("Enemy"))
                    {
                        continue;
                    }
                    if(gridCastTransform == null)
                    {
                        gridCastTransform = hitInfo.collider.transform;
                    }
                    //o transform mirado neste unico raycast está mais perto que o transform deste gridcast?
                    if (Vector3.Distance(transform.position, gridCastTransform.position) > Vector3.Distance(transform.position, hitInfo.transform.position))
                    {
                        gridCastTransform = hitInfo.transform;
                    }
                    if(gridCastTransform == closestEnemy)
                    {
                        maintainClosest = true;
                    }
                }
            }
        }

        if (gridCastTransform == null)
        {
            closestEnemy = null;
        }else if (closestEnemy != gridCastTransform)
        {
            if (closestEnemy == null)
            {
                closestEnemy = gridCastTransform;
            }else if (!maintainClosest&& Vector3.Distance(transform.position, gridCastTransform.position) < Vector3.Distance(transform.position, closestEnemy.position))
            {
                closestEnemy = gridCastTransform;
            }
        }


    }


    private void OnDrawGizmosSelected()
    {
        if (showGizmos)
        {
            for (int i = 0; i < resolution; i++)
            {
                for (int j = 0; j < resolution; j++)
                {
                    Gizmos.DrawLine(transform.position, getRayTargetPosition(i, j));
                }
            }
        }
    }

    Vector3 getRayTargetPosition(int a, int b)
    {
        return childCanvas.position  + transform.right * scale * (a - resolution / 2) + transform.forward * scale * (b - resolution / 2);
    }
}
