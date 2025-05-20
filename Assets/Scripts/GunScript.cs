using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Transform childCanvas;
    public int resolution=4;
    public float scale = 2f;
    Transform closestEnemy;
    public MeshRenderer AimObject;

    // Update is called once per frame
    void FixedUpdate()
    {
        availableEnemyCheck();
        if(closestEnemy != null)
        {
            AimObject.enabled = true;
            AimObject.transform.position = closestEnemy.position;
        }
        else
        {
            AimObject.enabled = false;
        }

    }

    void availableEnemyCheck()
    {
        Transform auxEnemy = null;
        for (int i = 0; i < resolution; i++)
        {
            for (int j = 0; j < resolution; j++)
            {
                RaycastHit hitInfo = new RaycastHit();
                Ray ray = new Ray(transform.position, getRayTargetPosition(i, j));
                Physics.Raycast(ray, out hitInfo);
                if (hitInfo.rigidbody != null)
                {
                    if (!hitInfo.collider.CompareTag("Enemy"))
                    {
                        continue;
                    }
                    auxEnemy = hitInfo.transform;
                    if (auxEnemy.CompareTag("Enemy"))
                    {
                        if (closestEnemy != null)
                        {
                            if (Vector3.Distance(transform.position, auxEnemy.position) < Vector3.Distance(transform.position, closestEnemy.position))
                            {
                                UpdateEnemy(auxEnemy);
                            }
                        }
                        else
                        {
                            UpdateEnemy(auxEnemy);
                        }
                    }
                }
            }
        }

    }

    void UpdateEnemy(Transform enemyIn)
    {
        if (enemyIn == null)
        {
            closestEnemy = null;
            return;
        }
        if (enemyIn == closestEnemy)
        {
            return;
        }
        else
        {
            closestEnemy = enemyIn;
        }
    }

    private void OnDrawGizmosSelected()
    {
        for (int i = 0; i < resolution; i++)
        {
            for (int j = 0; j < resolution; j++)
            {
                Gizmos.DrawLine(transform.position,getRayTargetPosition(i,j));
            }
        }
    }

    Vector3 getRayTargetPosition(int a, int b)
    {
        return childCanvas.position + transform.up + transform.right * scale * (a - resolution / 2) + transform.forward * scale * (b - resolution / 2);
    }
}
