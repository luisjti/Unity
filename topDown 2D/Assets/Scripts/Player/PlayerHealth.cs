using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public FloatVariavel vidaAtual, vidaMaxima;
    private float ataque = 1;

    private void TakeDamage (float quantidade)
    {
        vidaAtual.valor -= Mathf.Abs(quantidade);
        if (vidaAtual.valor <= 0)
        {
            vidaAtual.valor = 0;
            Debug.Log("Perdeu patrão!!!");
        }
    }
    
    private void HealDamage (float quantidade)
    {
        vidaAtual.valor += Mathf.Abs(quantidade);
        if (vidaAtual.valor > vidaMaxima.valor)
        {
            vidaAtual.valor = vidaMaxima.valor;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy"){
            InimigoVida inimigo = other.GetComponent<InimigoVida>();
            if (inimigo != null)
            {
                inimigo.tomarDano(ataque);
                Debug.Log($"Tentei causar {ataque} de dano no inimigo");
            }
        }
    }
}
