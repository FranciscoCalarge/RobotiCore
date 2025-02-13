using UnityEngine;

public class DestroyEffectScript : MonoBehaviour
{
    public float seconds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(this.gameObject, seconds);
    }
}
