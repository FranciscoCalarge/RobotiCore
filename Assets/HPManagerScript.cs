using UnityEngine;
using UnityEngine.SceneManagement;

public class HPManagerScript : MonoBehaviour
{
    float hp = 3;
    public Material characterMaterial;

    private void Start()
    {
        UpdateMaterial();
    }

    public void TakeDamage()
    {
        hp--;
        if (hp <= 0)
        {
            SceneManager.LoadScene(0);
        }
        UpdateMaterial();
    }

    void UpdateMaterial()
    {
        Debug.Log(hp/3);
        characterMaterial.SetFloat("_dmgAmt", hp/3f);
    }
}
