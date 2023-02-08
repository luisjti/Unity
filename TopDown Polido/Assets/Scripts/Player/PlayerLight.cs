using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerLight : MonoBehaviour
{
    private ControlLight controladorDeLuz;
    //private PlayerLife pf;
    
    void Start()
    {
        controladorDeLuz = GameObject.FindObjectOfType<ControlLight>();
        //pf = FindObjectOfType<PlayerLife>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if ("Luz".Equals(collision.gameObject.tag))
            controladorDeLuz.IniciaRecargaDaLuz();
    }
    void OnTriggerExit2D(Collider2D other) { 
        if("Luz".Equals(other.gameObject.tag))
            controladorDeLuz.ParaRecargaDaLuz();
    }

    public void ApagaLuzParaGameOver()
    {
        controladorDeLuz.ApagaLuzParaGameOver();
	    //pf.ReceberDano(9999);  
    }


}
