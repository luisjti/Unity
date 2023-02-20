using System.Collections;
using UnityEngine;

public class PlayerPotions : MonoBehaviour
{
    
    [SerializeField]
    private float valorVidaPocao; //Valor deve ser float

    [SerializeField]
    private float valorDanoPocao; //Valor deve ser float

    [SerializeField]
    private float valorVelocidadePocao; //Valor deve estar entre 0.0f e 3.0f para zero mudança e até 300% de velocidade

    [SerializeField]
    private LayerMask layersPocao; //Camadas com poções para acessar usar e destruir

    [SerializeField]
    private float tempoDaMudancaDaPocao = 1f; //Tempo usado para contar quanto se espera antes de consumir a poção toda


    private void OnTriggerEnter2D(Collider2D other) {
        if (((1<<other.gameObject.layer) & layersPocao) != 0){ //Se for uma poção
            soundFX.playSound(sound.HEAL);
            if (other.gameObject.CompareTag("Vida")){
                StartCoroutine(aplicarVida(valorVidaPocao));    //Adiciona a vida gradativamente
            }else if (other.gameObject.CompareTag("Veneno")){
                StartCoroutine(aplicarDano(valorDanoPocao));    //Retira a vida gradativamente
            }else if (other.gameObject.CompareTag("Velocidade")){
                StartCoroutine(aplicarVelocidade()); //Usa uma corrotina para mudar a velocidade por 5 segundos  
            }
            Destroy(other.gameObject); //Consuma, destrua a poção
        }
    }

    IEnumerator aplicarVelocidade(){
        PlayerMoves pm = GetComponent<PlayerMoves>(); //Pega o componente de movimento do player
        if (pm != null)
        {
            pm.AumentarVelocidade(valorVelocidadePocao / 2f);               //Metade da velocidade bônus acrescida
            yield return new WaitForSecondsRealtime(tempoDaMudancaDaPocao); //Espera o tempo padrão 
            pm.AumentarVelocidade(valorVelocidadePocao / 2f);               //Velocidade bônus total acrescida
            yield return new WaitForSecondsRealtime(tempoDaMudancaDaPocao); //Espera o tempo padrão 
            pm.DiminuirVelocidade(valorVelocidadePocao / 2f);               //Metade da velocidade bônus decrescida
            yield return new WaitForSecondsRealtime(tempoDaMudancaDaPocao); //Espera o tempo padrão para desacelerar metade
            pm.DiminuirVelocidade(valorVelocidadePocao / 2f);               //Velocidade bônus total decrescida

        }
    }

    IEnumerator aplicarVida(float vida){
        PlayerLife pf = GetComponent<PlayerLife>(); //Pega o componente de vida do player
        if (pf != null)
        {
            pf.ReceberVida(vida / 3f);
            yield return new WaitForSecondsRealtime(tempoDaMudancaDaPocao); //Espera o tempo padrão 
            pf.ReceberVida(vida / 3f);
            yield return new WaitForSecondsRealtime(tempoDaMudancaDaPocao); //Espera o tempo padrão 
            pf.ReceberVida(vida / 3f);
        }
    }

    IEnumerator aplicarDano(float dano){
        PlayerLife pf = GetComponent<PlayerLife>(); //Pega o componente de vida do player
        if (pf != null)
        {
            pf.ReceberDano(dano / 3f);
            yield return new WaitForSecondsRealtime(tempoDaMudancaDaPocao); //Espera o tempo padrão 
            pf.ReceberDano(dano / 3f);
            yield return new WaitForSecondsRealtime(tempoDaMudancaDaPocao); //Espera o tempo padrão 
            pf.ReceberDano(dano / 3f);
        }
    }
}
