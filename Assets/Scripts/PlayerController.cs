using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 initialPos;
    public float movespeed = 5f;
    public float gravitySpeed = 1f;
    public Rigidbody _rb;
    public Animator _animator;


/*    float verticalVelocity;
*/
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 moveVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Debug.Log(_rb.linearVelocity.sqrMagnitude);
        if (Mathf.Pow(_rb.linearVelocity.magnitude,2 ) < .1f)
        {
            _animator.SetBool("isMoving", false);
        }
        else
        {
            _animator.SetBool("isMoving", true);
        }

        if (Mathf.Abs( moveVector.x)> 0)
        {
            transform.Rotate(transform.up,moveVector.x*Time.deltaTime*30*movespeed);
        }

        if (Mathf.Abs(moveVector.y) > 0) { 
            transform.position+=transform.forward*moveVector.y*Time.deltaTime * movespeed;
        }

        _animator.SetFloat("onAir", Mathf.Clamp01(Mathf.Abs(_rb.linearVelocity.y/2)));

        if (Input.GetKey(KeyCode.Space))
        {
            _rb.AddForce(transform.up*15,ForceMode.Acceleration);
        }

/*        if (transform.position.y < initialPos.y)
        {
            verticalVelocity = 0f;
        }
        else
        {
            verticalVelocity +=  -Time.deltaTime*gravitySpeed;
        }

        transform.position += verticalVelocity * Time.deltaTime*transform.up;
*/    }
}
