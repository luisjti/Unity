using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private float danoDoInimigo = 0.7f;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            PlayerLife player = other.GetComponent<PlayerLife>();
            if (!player.invulneravel){
                player.ReceberDano(danoDoInimigo);
            }   
        }
    }
}
