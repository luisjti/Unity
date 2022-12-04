using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpEffect : ScriptableObject
{
    public abstract void Apply (GameObject alvo);
    //Método abstrato para ser implementado no script de cada power up
}
