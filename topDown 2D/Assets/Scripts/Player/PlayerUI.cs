using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public PlayerClass playerClass;

    [SerializeField]
    private TextMeshProUGUI nomeText;

    [SerializeField]
    private TextMeshProUGUI vidaText;

    private void Start() {
        nomeText.text = playerClass.name;
        vidaText.text = $"Vida: {playerClass.vida}";
    }
}
