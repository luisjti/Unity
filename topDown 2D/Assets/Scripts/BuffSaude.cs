using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUPs/BuffSaude")]
public class BuffSaude : PowerUpEffect
{
   public float quantidade;
   public override void Apply(GameObject alvo)
   {
        alvo.GetComponent<PlayerHealth>().vidaAtual.valor += Mathf.Abs(quantidade);
   }
}
