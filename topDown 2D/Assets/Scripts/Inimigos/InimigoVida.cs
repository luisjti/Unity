using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoVida : MonoBehaviour
{
    [SerializeField]
    private float vidaMaxima = 3;
    [SerializeField]
    private float vidaAtual;
    [SerializeField]
    private float ataque;

    private void Awake()
    {
        vidaAtual = vidaMaxima;
    }

    public void tomarDano(float dano)
    {
        vidaAtual -= Mathf.Abs(dano);
        if (vidaAtual <= 0)
        {
            Derrotado();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            Debug.Log($"Ataca o jogador causando {ataque} de dano");
        }
    }

    private void Derrotado()
    {
        Destroy(gameObject);
    }
}
