using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyAttack : MonoBehaviour
{
    public Animator animator;
    public EstadosData state;

    [SerializeField]
    private float danoDoInimigo = 0.7f;

   private void Awake () {
	animator = GetComponent<Animator>();
	
}
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            PlayerLife player = other.GetComponent<PlayerLife>();
            state = EstadosData.Attack;
            animator.SetInteger("estado", (int)state);
            if (!player.invulneravel){
                player.ReceberDano(danoDoInimigo);
            } 
        }
    }
}
