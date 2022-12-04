using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pote : MonoBehaviour
{
    public UnityEvent pegarPote;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            pegarPote.Invoke();
        }
   }

    
    public void exemplo(){
        
    }
}
