using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ActivateLight : MonoBehaviour
{

    private PlayerMoves pm;
    private Light2D fireLight;

    // Start is called before the first frame update
    void Start()
    {
         pm = FindObjectOfType<PlayerMoves>();
 	   fireLight = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(pm.transform.position, transform.position) < 8.0f) 
            { 
			fireLight.intensity = 1f;
			
		}
	  else 
            { 
			fireLight.intensity = 0f;
			
		}
    }
}
