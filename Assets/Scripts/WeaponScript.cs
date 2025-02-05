using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private Transform _shootPosition;
    private float _projectileInterval = .5f;
    private float _weaponCD = 1.5f;
    private float stanceCD { get; set; }
    private float _stanceCD { get => stanceCD; set {stanceCD= Mathf.Lerp(stanceCD, value, .5f); } }
    private float _initialWeaponCD;
    private float animatorLerp =0;
    private MovementScript _movementScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _initialWeaponCD = _weaponCD;
        _movementScript= (MovementScript)MovementScript.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        animatorLerp =Mathf.InverseLerp(_initialWeaponCD, 0, _stanceCD);
        _movementScript._aimStanceLerp = animatorLerp;


        if (Input.GetMouseButton(1))
        {
            _weaponCD -= Time.deltaTime;
            _stanceCD -= Time.deltaTime*2;

            if (_weaponCD < 0)
            {
                _weaponCD += _projectileInterval;
                GameObject aux =  Instantiate(BulletPrefab,_shootPosition.position , _shootPosition.localRotation);
                aux.GetComponent<Rigidbody>().linearVelocity = transform.forward*20;
                aux.GetComponent<BulletScript>().spawnTag = transform.tag;
            }
        }
        else
        {
            _weaponCD = _initialWeaponCD;
            _stanceCD = _initialWeaponCD;
        }
    }
}
