using UnityEngine;

public class HPManagerScript : MonoBehaviour
{
    int hp = 3;
    public Material characterMaterial;

    public void TakeDamage()
    {
        hp--;
        UpdateMaterial();
    }

    void UpdateMaterial()
    {
        characterMaterial.SetFloat("",1f);
    }
}
