using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueNPC : MonoBehaviour
{
    public GameObject panelDialogo;
    public TextMeshProUGUI textoDialogo;
    public string[] dialogo;
    private int indice = 0;

    [SerializeField]
    private GameObject textoDeAjuda;

    public float velocidadeTexto= 3f;
    public bool pertoParaFalar = false;

    private Coroutine co;

    private void Awake()
    {
        panelDialogo.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && pertoParaFalar)
        {
            if (panelDialogo.activeInHierarchy)
            {
                limparTela();
            }
            else
            {
                panelDialogo.SetActive(true);
                co = StartCoroutine(Digitar());
            }
        }
    }

    public void limparTela()
    {
        textoDialogo.text = "";
        indice = 0;
        if (co != null)
        {
            StopCoroutine(co);
        }
        panelDialogo.SetActive(false);
    }

    IEnumerator Digitar()
    {
        foreach (char letra in dialogo[indice].ToCharArray())
        {
            textoDialogo.text += letra;
            yield return new WaitForSecondsRealtime(velocidadeTexto/100);
        }
    }
    
    public void ProximaLinha()
    {

        if (indice < dialogo.Length -1)
        {
            indice++;
            textoDialogo.text = "";
            StartCoroutine(Digitar());
        }
        else
        {
            limparTela();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pertoParaFalar = true;
            textoDeAjuda.SetActive(true);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        textoDeAjuda.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        textoDeAjuda.SetActive(false);
        limparTela();
        if (collision.CompareTag("Player"))
        {
            pertoParaFalar = false;
        }
    }
}
