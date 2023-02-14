using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlaMenu : MonoBehaviour
{
    [SerializeField]
    private Button botaoIniciar;
    [SerializeField]
    private Button botaoControle;
    [SerializeField]
    private Button botaoCreditos;
    [SerializeField]
    private Button botaoVoltar;
    [SerializeField]
    private Button botaoSair;

    [SerializeField]
    private GameObject painelControles;
    [SerializeField]
    private GameObject painelCreditos;

    public void IniciarJogo()
    {
        SceneManager.LoadScene("Nivel_Zero");
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }

    public void Controles()
    {
        botaoIniciar.gameObject.SetActive(false);
        botaoControle.gameObject.SetActive(false);
        botaoCreditos.gameObject.SetActive(false);
        botaoSair.gameObject.SetActive(false);
        botaoVoltar.gameObject.SetActive(true);
        painelControles.SetActive(true);
        painelCreditos.SetActive(false);
    }

    public void Creditos()
    {
        botaoIniciar.gameObject.SetActive(false);
        botaoControle.gameObject.SetActive(false);
        botaoCreditos.gameObject.SetActive(false);
        botaoSair.gameObject.SetActive(false);
        botaoVoltar.gameObject.SetActive(true);
        painelCreditos.SetActive(true);
        painelControles.SetActive(false);
    }

    public void Voltar()
    {
        botaoIniciar.gameObject.SetActive(true);
        botaoControle.gameObject.SetActive(true);
        botaoCreditos.gameObject.SetActive(true);
        botaoSair.gameObject.SetActive(true);
        botaoVoltar.gameObject.SetActive(false);
        painelCreditos.SetActive(false);
        painelControles.SetActive(false);
    }
}
