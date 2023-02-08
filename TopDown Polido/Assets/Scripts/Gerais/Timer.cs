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
    
    private void Start()
    {
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
            var str = $"Tempo: {(int)tmp} segundos";
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
        tempoMaximoDaPartida = 60f;
        tempoAtualDaPartida = 0f;
    }



}
