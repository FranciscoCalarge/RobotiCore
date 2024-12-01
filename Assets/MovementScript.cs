using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public Rigidbody body;
    public Transform camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputVec3 = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        body.MovePosition(transform.position+inputVec3/10);
        Vector3 lookAtVec3 = camera.transform.forward;
        lookAtVec3.Scale(new Vector3(1, 0, 1));
        body.MoveRotation(Quaternion.FromToRotation(transform.forward, lookAtVec3 ));
    }
}
