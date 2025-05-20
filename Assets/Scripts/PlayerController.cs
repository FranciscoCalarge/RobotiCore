using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movespeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
    }
}
