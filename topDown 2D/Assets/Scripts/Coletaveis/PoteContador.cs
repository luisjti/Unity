using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PoteContador : MonoBehaviour
{
    [SerializeField]
    private int quantidadePotes;

    public void IncrementandoNumeroPotes()
    {
        quantidadePotes++;
        GetComponent<TextMeshProUGUI>().text = $"Potes: {quantidadePotes}";
    }
}
