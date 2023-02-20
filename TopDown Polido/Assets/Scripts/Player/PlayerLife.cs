using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField]
    private float vidaMaxP;

    [SerializeField]
    private float vidaAtualP;

    [SerializeField]
    private BarraDeVida barraDeVidaP;

    private SpriteRenderer sprite;

    public bool invulneravel = false;

    [SerializeField]
    private GameObject menuGameOver;

    private void Awake() {
        this.vidaAtualP = this.vidaMaxP; //O inimigo tem a vida atual igual a vida máxima 
        if (barraDeVidaP != null){
            this.barraDeVidaP.VidaMaximaDoSlider = this.vidaMaxP; //A barra de vida tem a vida máxima igual a vida máxima
            this.barraDeVidaP.VidaAtualDoSlider = this.vidaAtualP; //A barra de vida tem a vida atual igual a vida atual
        }
        sprite = GetComponent<SpriteRenderer>();
    }

    public void ReceberDano(float dano){

        this.vidaAtualP -= Mathf.Abs(dano); //Retira da vida do inimigo, o dano que lhe causaram

        this.invulneravel = true; //Ativa a invulnerabilidade por 1 segundo

        this.barraDeVidaP.VidaAtualDoSlider = this.vidaAtualP; //Atualiza no slider o dano sofrido
        
        if (this.vidaAtualP <= 0){
            Morrer();
        }
        else {
            StartCoroutine(MudarSpriteSofreuDano()); //Realiza a animação de dano
        }
    }

    public void ReceberVida(float vida) {
        this.vidaAtualP += Mathf.Abs(vida); //Adiciona a vida do player, a vida que lhe deram

        this.barraDeVidaP.VidaAtualDoSlider = this.vidaAtualP; //Atualiza no slider o dano curado

        if (this.vidaAtualP > this.vidaMaxP){ //Se curar mais que o máximo
            this.vidaAtualP = this.vidaMaxP; //Limita a vida no máximo
        }
    }

    private void Morrer()
    {
        soundFX.playSound(sound.DEATH_PLAYER); //Som de morte
        ApagaLuzPlayer(); //Desliga a luz 
        this.barraDeVidaP.gameObject.SetActive(false); //Desativa a barra de vida
        MostraMenuGameOver(); //Exibe o menu de game over
    }

    IEnumerator MudarSpriteSofreuDano()
    {
        sprite.color = Color.red; //Muda a cor da sprite durante 1 segundo
        yield return new WaitForSecondsRealtime(1f);
        sprite.color = Color.white; //Muda a cor da sprite para a padrão (branco)
        yield return new WaitForSecondsRealtime(0.5f);
        this.invulneravel = false; //Após a animação de dano, desativa a invulnerabilidade
    }
    
    private void ApagaLuzPlayer()
    {
        PlayerMoves.GameOver = true;
        var luz = FindObjectOfType<PlayerLight>();
        luz.ApagaLuzParaGameOver();
    }

    public void MostraMenuGameOver()
    {
        menuGameOver.SetActive(true);
    }

}
