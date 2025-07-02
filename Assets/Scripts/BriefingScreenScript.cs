using System.Collections;
using UnityEngine;
using TMPro;

public class BriefingScreenScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _texto;
    private float _velocidadeDoTexto = 0.015f;
    [TextArea(2, 5)]
    public string texto;
    
    public bool isShowing { get; private set; }
    public bool speed;

    private IEnumerator _coroutineDoEfeito;

    private void Start()
    {
        MostrarTextoLetraPorLetra(texto);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space)) { 
            speed = true;
        }
        else
        {
            speed = false;
        }
    }

    public void MostrarTextoLetraPorLetra(string textoDoDialogo)
    {
        _texto.text = textoDoDialogo;

        _coroutineDoEfeito = EfeitoLetraPorLetra();
        StartCoroutine(_coroutineDoEfeito);
        isShowing = true;
    }

    public void MostrarTextoTodo()
    {
        StopCoroutine(_coroutineDoEfeito);
        _texto.maxVisibleCharacters = _texto.text.Length;

        isShowing = false;
    }

    private IEnumerator EfeitoLetraPorLetra()
    {
        int caracteresTotais = _texto.text.Length;
        _texto.maxVisibleCharacters = 0;

        for (int i = 0; i <= caracteresTotais; i++)
        {
            _texto.maxVisibleCharacters = i;
            yield return new WaitForSeconds(speed?_velocidadeDoTexto/2:_velocidadeDoTexto*2);
        }
        isShowing = false;
    }
}