using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public FloatVariavel vidaAtual, vidaMaxima;

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
}
