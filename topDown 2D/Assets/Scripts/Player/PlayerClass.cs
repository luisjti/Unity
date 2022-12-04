using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Classes/Player")]
public class PlayerClass : ScriptableObject
{    
    public string nome;
    public float vida;
    public float velocidadeMovimento;
    public Color corLuz;
}
