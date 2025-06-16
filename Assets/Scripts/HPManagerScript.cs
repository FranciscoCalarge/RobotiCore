using UnityEngine;
using UnityEngine.SceneManagement;

public class HPManagerScript : MonoBehaviour
{
    public float hp = 5f;
    public Material characterMaterial;
    float initialHP;

    private void Start()
    {
        initialHP = hp;
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
        if (hp == initialHP) {
            characterMaterial.SetFloat("_dmgAmt",1f);
        }
        else
        {
            characterMaterial.SetFloat("_dmgAmt", hp/initialHP);
        }
        
    }
}
