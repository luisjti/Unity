using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objetosPrefab;
    [SerializeField]
    private GameObject[] posicoes;
    [SerializeField]
    private int numeroItensDaFase = 1;
    [SerializeField]
    private float spawnTime;
    private bool[] posicaoOcupada;
    private int i;
    private int randomPos, randomItem;

    private void Start()
    {
        //Limita a quantidade de itens entre 1 e o n�mero de locais pos�veis para spawnar o item
        numeroItensDaFase = Mathf.Clamp(numeroItensDaFase, 1, posicoes.Length); 
        for (i=0; i < numeroItensDaFase; i++) 
        { //Invoca a fun��o de cria��o de itens aleat�rios no in�cio do game
            Invoke("SpawnRandom", spawnTime); 
        }
        /*
        for (i=0; i < posicoes.Length -1; i++)
        {
            posicaoOcupada[i] = false;
        }*/
        
    }

    private void SpawnRandom()
    {
        randomItem = Random.Range(0, objetosPrefab.Length); //Sorteia qual o tipo de item
        randomPos = Random.Range(0, posicoes.Length); //Sorteia qual o local para o item
        /*
        posicaoOcupada[randomPos] = true;
        
        while (posicaoOcupada[randomPos])
        {
                randomPos = Random.Range(0, posicoes.Length);
        }*/

        //Cria um item com o tipo sorteado, em um local sorteado
        Instantiate(objetosPrefab[randomItem], posicoes[randomPos].transform.position, transform.rotation); 
    }
}
