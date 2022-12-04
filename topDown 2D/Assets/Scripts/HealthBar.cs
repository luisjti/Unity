using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider; 
    public FloatVariavel VidaAtual, VidaMaxima;
    public Image imagemPreenchimento;

    private void Awake  ()
    {
        slider = GetComponent<Slider>();;
    }

    void Update()
    {
        if (slider.value <= slider.minValue)
        {
            imagemPreenchimento.enabled = false;
        }

        if (slider.value >= slider.maxValue && !imagemPreenchimento.enabled)
        {
            imagemPreenchimento.enabled = true;
        }

        float valorPreenchimento = VidaAtual.valor / VidaMaxima.valor;

        if (valorPreenchimento < slider.maxValue * 0.25) //Menor que 25% da vida total
        {
            imagemPreenchimento.color = Color.red;  //Faz a barra ficar vermelha
        }
        if (valorPreenchimento >= (slider.maxValue * 0.25) && valorPreenchimento < (slider.maxValue * 0.75)){  //Entre 25% e 75% da vida total
            imagemPreenchimento.color = Color.magenta; //Faz a barra ficar roxo
        }
        if (valorPreenchimento >= slider.maxValue * 0.75) {  //Se estiver com mais de 75% da vida total
            imagemPreenchimento.color = Color.yellow; //Faz a barra ficar amarela
        }
        slider.value = valorPreenchimento;
    }
}
