using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float tempoMaximoDaPartida;
    [SerializeField]
    private float tempoAtualDaPartida;
    [SerializeField]
    private TextMeshProUGUI textoDoTempoRestante;
    private const float tempoZeradoNaPartida = 0f;
    private float tempoMaximoOriginalDaPartida;


    private void Start()
    {
        tempoMaximoOriginalDaPartida = tempoMaximoDaPartida;
        ReiniciaTempoPartida();
    }


    void Update()
    {
        contarTempo();
    }

    private void contarTempo() {
        if (tempoMaximoDaPartida > tempoAtualDaPartida)
        {
            tempoAtualDaPartida += Time.deltaTime;
            float tmp = Mathf.Clamp(tempoMaximoDaPartida - tempoAtualDaPartida, tempoZeradoNaPartida, tempoMaximoDaPartida);
            var str = $"{(int)tmp} s";
            textoDoTempoRestante.text = str;
        }
        else
        {
            PlayerMoves.GameOver = true;
            FindObjectOfType<PlayerLife>().MostraMenuGameOver();
        }
    }

    public void ReiniciaTempoPartida()
    {
        tempoMaximoDaPartida = tempoMaximoOriginalDaPartida;
        tempoAtualDaPartida = 0f;
    }



}
