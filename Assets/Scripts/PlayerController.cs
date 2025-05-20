using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 initialPos;
    public float movespeed = 5f;
    public float gravitySpeed = 1f;

    float verticalVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialPos = transform.position;
        verticalVelocity = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 moveVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(Mathf.Abs( moveVector.x)> 0)
        {
            transform.Rotate(transform.up,moveVector.x*Time.deltaTime*30*movespeed);
        }

        if (Mathf.Abs(moveVector.y) > 0) { 
            transform.position+=transform.forward*moveVector.y*Time.deltaTime * movespeed;
        }

        if (Input.Ac)
        {
            Debug.Log("espaco");
            verticalVelocity += 5f;
            transform.position += Vector3.up;
        }

        if (transform.position.y < initialPos.y)
        {
            verticalVelocity = 0f;
        }
        else
        {
            verticalVelocity +=  -Time.deltaTime*gravitySpeed;
        }

        transform.position += verticalVelocity * Time.deltaTime*transform.up;
    }
}
