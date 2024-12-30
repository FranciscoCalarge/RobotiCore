using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private Transform _shootPosition;
    private float _projectileInterval = .5f;
    private float _weaponCD = 1.5f;
    private float _initialWeaponCD;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _initialWeaponCD = _weaponCD;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _weaponCD -= Time.deltaTime;
            if (_weaponCD < 0)
            {
                _weaponCD += _projectileInterval;
                GameObject aux =  Instantiate(BulletPrefab,_shootPosition.position , _shootPosition.localRotation);
                aux.GetComponent<Rigidbody>().linearVelocity = transform.forward*20;

            }
        }
        else
        {
            _weaponCD = _initialWeaponCD;
        }
    }
}
