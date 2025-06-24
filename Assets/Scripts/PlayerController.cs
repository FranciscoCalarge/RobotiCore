using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movespeed = 5f;
    public Rigidbody _rb;
    public Animator _animator;

    float verticalLerp=0f;


/*    float verticalVelocity;
*/
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 moveVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Mathf.Max(Mathf.Abs(moveVector.x),Mathf.Abs(moveVector.y),Mathf.Abs( _rb.linearVelocity.y),Mathf.Abs(Input.GetAxis("Strafe")))< .1f)
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

        if (Mathf.Abs(moveVector.y) > 0)
        {
            transform.position += transform.forward * moveVector.y * Time.deltaTime * movespeed;
        }
        if (Mathf.Abs(Input.GetAxis("Strafe")) > 0)
        {
            transform.position += transform.right * Input.GetAxis("Strafe") * Time.deltaTime * movespeed;
        }
        if(!Physics.Raycast(transform.parent.transform.position,Vector3.down, .5f, LayerMask.NameToLayer("Ground")))
        {
            verticalLerp = Mathf.Lerp(verticalLerp, Mathf.Abs(_rb.linearVelocity.y), .5f);
            _animator.SetFloat("onAir", Mathf.Pow(verticalLerp, 5f));
        }

        if (Input.GetKey(KeyCode.Space))
        {
            
            _rb.AddForce(transform.up*1000*Time.deltaTime,ForceMode.Acceleration);
            Debug.Log("space");
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
