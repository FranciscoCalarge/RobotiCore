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
        characterMaterial.SetFloat("_max_HP", hp);
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
        Debug.Log("Update Material:" + hp.ToString());
        characterMaterial.SetFloat("_currentHP", hp);
        
    }
}
