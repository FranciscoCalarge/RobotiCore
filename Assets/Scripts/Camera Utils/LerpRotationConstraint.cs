using UnityEngine;

public class LerpRotationConstraint : MonoBehaviour
{
    public Transform target;
    public float t_variable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation,t_variable);
    }
}
