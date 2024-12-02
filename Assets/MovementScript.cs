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
        Vector3 lookOffset = transform.position-camera.position;
        transform.forward = new Vector3(lookOffset.x,0,lookOffset.z);
        if(Input.GetKey(KeyCode.Space)) body.AddForce(transform.up*800*Time.deltaTime, ForceMode.Acceleration);
        body.MovePosition(transform.position+camera.right*Input.GetAxis("Horizontal")/10+camera.forward*Input.GetAxis("Vertical")/10);

    }
}
