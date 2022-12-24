using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField]
    private float vidaMax;

    [SerializeField]
    private float vidaAtual;

    [SerializeField]
    private BarraDeVida barraDeVida;

    private SpriteRenderer sprite;

    [SerializeField]
    private Color corPadrao;

    private void Awake() {
        this.vidaAtual = this.vidaMax; //O inimigo tem a vida atual igual a vida máxima 
        this.barraDeVida.VidaMaximaDoSlider = this.vidaMax; //A barra de vida tem a vida máxima igual a vida máxima
        this.barraDeVida.VidaAtualDoSlider = this.vidaAtual; //A barra de vida tem a vida atual igual a vida atual
        sprite = GetComponent<SpriteRenderer>();
    }

    public void ReceberDano(float dano){

        this.vidaAtual -= Mathf.Abs(dano); //Retira da vida do inimigo, o dano que lhe causaram

        this.barraDeVida.VidaAtualDoSlider = this.vidaAtual; //Atualiza o slider que a vida atual mudou
        
        if (this.vidaAtual <= 0){
            GameObject.Destroy(this.gameObject); //Inimigo morreu
        }else {
            //Inimigo tomou dano, não ativa pois os inimigos usam da cor padrão para se destacarem dos demais
            //StartCoroutine(MudarCorSofreuDano()); //Faz uma notificação visual que tomou dano
        }
    }

    /*
    IEnumerator MudarCorSofreuDano()
    {
        if (sprite != null){
            sprite.color = Color.red;
            yield return new WaitForSecondsRealtime(0.3f);
            sprite.color = corPadrao;
        }
    }
    */
}
