using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LuzDinamica : MonoBehaviour
{
   [SerializeField]
   private float tempoRestante;

   [SerializeField]
   private bool contadorAtivo = false;

   [SerializeField]
   private TextMeshProUGUI tempoRestanteTXT;

   private void Start()
   {
        contadorAtivo = true;
        tempoRestanteTXT = GetComponent<TextMeshProUGUI>();
   }

   private void Update()
   {
        if (contadorAtivo)
        {
            if (tempoRestante > 0)
            {
                tempoRestante -= Time.fixedDeltaTime;
                updateTimer(tempoRestante);
            }else{
                Debug.Log ("Tempo acabou!");
                tempoRestante = 0;
                contadorAtivo = false;
            }
        }
   }

   private void updateTimer (float tempoAtual)
   {
        tempoAtual += 1;

        float minutos = Mathf.FloorToInt(tempoAtual / 60);
        float segundos = Mathf.FloorToInt(tempoAtual % 60);

        tempoRestanteTXT.text = string.Format("{0:00} : {1:00}", minutos, segundos);
   }
}
