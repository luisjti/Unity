using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[SerializeField]
public class FloatReferenciador 
{
    public bool usandoConstante;
    public float constante;
    public FloatVariavel variavel;

    public float Valor
    {
        get { return usandoConstante? constante : variavel.valor; }
    }
}
