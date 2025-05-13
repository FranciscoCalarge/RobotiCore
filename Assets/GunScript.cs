using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Transform childCanvas;
    public int resolution=4;
    public float scale = 2f;
    Transform closestEnemy;

    // Update is called once per frame
    void FixedUpdate()
    {
        availableEnemyCheck();
        if(closestEnemy != null)
            closestEnemy.transform.position = transform.forward;
    }

    void availableEnemyCheck()
    {
        Transform auxEnemy = null;
        for (int i = 0; i < resolution; i++)
        {
            for (int j = 0; j < resolution; j++)
            {
                RaycastHit hitInfo = new RaycastHit();
                Ray ray = new Ray(transform.position, childCanvas.position + transform.up + transform.right * scale * (i - resolution / 2) + transform.forward * scale * (j - resolution / 2));
/*                Physics.Raycast();
*/                if (hitInfo.rigidbody!=null)
                {
                    auxEnemy = hitInfo.transform;
                    if(auxEnemy!=null)
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
        Debug.Log(enemyIn.name.ToString());
        if (enemyIn==null)
        {
            closestEnemy = null;
            return;
        }
        if ( enemyIn == closestEnemy)
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
                Gizmos.DrawLine(transform.position,childCanvas.position+transform.up+transform.right*scale*(i-resolution/2)+transform.forward*scale*(j - resolution / 2));
            }
        }
    }
}
