using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentaCameraFimDeJogo : MonoBehaviour
{
    [SerializeField]
    public float posicaoInicial = 1.0f;
    [SerializeField]
    public float posicaoFinal = 2.5f;
    [SerializeField]
    public float velocidade = 0.1f;

    private bool podeSubir = false;
    private bool podeDescer = true;

    void Start()
    {
        posicaoInicial = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= posicaoFinal)
        {
            podeSubir = true;
            podeDescer = false;
        }

        if (transform.position.y >= posicaoInicial)
        {
            podeSubir = false;
            podeDescer = true;
        }


        if (podeSubir)
        {
            transform.Translate(Vector3.up * velocidade * Time.deltaTime);
        }
        else if(podeDescer)
            transform.Translate(Vector3.down * velocidade * Time.deltaTime);
    }
}
