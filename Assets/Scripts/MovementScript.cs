using UnityEngine;
using UnityEngine.UI;

public class MovementScript : MonoBehaviour
{
    public Rigidbody body;
    public Transform PlayerCamera;
    public bool isCameraParented;

    [SerializeField] private RectTransform boostRect;
    [SerializeField] private float _boostCD =5f;
    private Animator _animator;
    private float _initialBoostCD;
    private bool _isBoostEmpty=false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        body = GetComponent<Rigidbody>();
        _initialBoostCD = _boostCD;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isBoostEmpty)
        {
            _boostCD += Time.deltaTime;
        }
        if (_boostCD > _initialBoostCD) { _isBoostEmpty = false; _boostCD = _initialBoostCD; boostRect.GetComponent<RawImage>().color = Color.blue; }
        boostRect.localScale = new Vector3(1, Mathf.Min(_boostCD/_initialBoostCD,1),1);
        
        Vector3 lookOffset = transform.position-PlayerCamera.position;
        if(isCameraParented)
        {
            transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X")*Mathf.Abs(Input.GetAxis("Mouse X")));
        }
        else
        {
            transform.forward = new Vector3(lookOffset.x, 0, lookOffset.z);
        }

        if(_boostCD > 0)
        {
            if (Input.GetKey(KeyCode.Space) && !_isBoostEmpty) {
                body.AddForce(transform.up * 800 * Time.deltaTime, ForceMode.Acceleration);
                _boostCD -= Time.deltaTime;
            }else {
                _boostCD += Time.deltaTime/1.2f;
            }
        }
        else
        {
            _boostCD = 0;
            _isBoostEmpty = true;
            boostRect.GetComponent<RawImage>().color = Color.red;
        }
        body.MovePosition(transform.position+PlayerCamera.right*Input.GetAxis("Horizontal")/10+PlayerCamera.forward*Input.GetAxis("Vertical")/10);

        _animator.SetFloat("BlendX", Input.GetAxis("Horizontal"));
        _animator.SetFloat("BlendY", Input.GetAxis("Vertical"));

    }
}
