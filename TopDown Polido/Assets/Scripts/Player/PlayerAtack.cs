using System.Collections;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    [SerializeField]
    private Transform pontoDeAtaqueDaEsquerda;

    [SerializeField]
    private Transform pontoDeAtaqueDaDireita;

    [SerializeField]
    private Transform pontoDeAtaqueDeCima;

    [SerializeField]
    private Transform pontoDeAtaqueDeBaixo;

    [SerializeField]
    private float raioDeAtaque;

    [SerializeField]
    private float danoDeAtaque;

    [SerializeField]
    private LayerMask layersAtacaveis;

    [SerializeField]
    private PlayerMoves jogador;

    public Transform pontoDeAtaque;

    public Animator animator;

    private void Awake() {
        pontoDeAtaque = pontoDeAtaqueDaDireita; //Player começa atacando para a direita
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)){    //Se apertar o esquerdo do mouse ou espaço
                soundFX.playSound(sound.ATTACK_PLAYER);
                animator.SetInteger("Attack", 1);    
                Atacar();           //Você ataca
                StartCoroutine(waiter()); //Espera um tempo até poder atacar novamente
        }
    }

    private bool PodeAtacar(Transform inimigo)
    {
        var posicaoInimigo = new Vector2(transform.position.x, transform.position.y);
        var posicaoPlayer = new Vector2(inimigo.transform.position.x, inimigo.transform.position.y);

        var vetorInimigoPlayer = posicaoPlayer - posicaoInimigo;
        var tamanhoRayCast = posicaoInimigo + vetorInimigoPlayer.normalized * raioDeAtaque;

        RaycastHit2D hit = Physics2D.Raycast(posicaoInimigo, vetorInimigoPlayer.normalized, raioDeAtaque, 3);
        Debug.DrawLine(posicaoInimigo, tamanhoRayCast, Color.red);

        if (hit.collider == null)
            return false;
        if ("Cenario".Equals(hit.collider.tag))
            return false;
        Debug.Log("hit tag:" + hit.collider.tag);
        Debug.Log("hit name:" + hit.collider.name);
        return true;
    }

    private void OnDrawGizmos() {

        Gizmos.color = Color.white; //Por padrão é branco
        if (this.pontoDeAtaqueDaDireita != null){    
            Gizmos.DrawWireSphere(this.pontoDeAtaqueDaDireita.position, this.raioDeAtaque); //Cria a linha de visão do player olhando para direita
        }
        if (this.pontoDeAtaqueDaEsquerda != null){    
            Gizmos.DrawWireSphere(this.pontoDeAtaqueDaEsquerda.position, this.raioDeAtaque); //Cria a linha de visão do player olhando para esquerda
        }
        if (this.pontoDeAtaqueDeCima != null){    
            Gizmos.DrawWireSphere(this.pontoDeAtaqueDeCima.position, this.raioDeAtaque); //Cria a linha de visão do player olhando para cima
        }
        if (this.pontoDeAtaqueDeBaixo != null){    
            Gizmos.DrawWireSphere(this.pontoDeAtaqueDeBaixo.position, this.raioDeAtaque); //Cria a linha de visão do player olhando para baixo
        }
        AtualizarDirecaoDeAtaque();
        Gizmos.color = Color.red; //Se estiver atacando é vermelho
        Gizmos.DrawWireSphere(pontoDeAtaque.position, this.raioDeAtaque);
    }

    private void Atacar(){

        AtualizarDirecaoDeAtaque();
        Collider2D colliderInimigo = Physics2D.OverlapCircle(pontoDeAtaque.position, this.raioDeAtaque, this.layersAtacaveis); //Cria a zona de ataque do player
        if (colliderInimigo != null){
            if (PodeAtacar(colliderInimigo.transform))
            {    
                EnemyLife inimigo = colliderInimigo.GetComponent<EnemyLife>(); //Se encontrou um inimigo, descobre quem é
                if (inimigo != null){
                    inimigo.ReceberDano(this.danoDeAtaque); //Se encontrou quem é, causa dano nele
                }
            }
        }
    }

    private void AtualizarDirecaoDeAtaque()
    {
        if (this.jogador.direcaoDeMovimento == DirecaoDeMovimento.Direita){ //Se olha para direita, ataca para direita
            pontoDeAtaque = this.pontoDeAtaqueDaDireita;
            animator.SetInteger("AttackDirection", 0);
        }
        else if (this.jogador.direcaoDeMovimento == DirecaoDeMovimento.Esquerda){ //Se olha para esquerda, ataca para esquerda
            pontoDeAtaque = this.pontoDeAtaqueDaEsquerda;
            animator.SetInteger("AttackDirection", 1);
        }

        if (this.jogador.direcaoDeMovimento == DirecaoDeMovimento.Cima){ //Se olha para cima, ataca para cima
            pontoDeAtaque = this.pontoDeAtaqueDeCima;
            animator.SetInteger("AttackDirection", 2);
        }
        else if (this.jogador.direcaoDeMovimento == DirecaoDeMovimento.Baixo){ //Se olha para baixo, ataca para baixo
            pontoDeAtaque = this.pontoDeAtaqueDeBaixo;
            animator.SetInteger("AttackDirection", 3);
        }
    }

    IEnumerator waiter()
    {
        //Wait for 1 second
        yield return new WaitForSeconds(0.75f);
        animator.SetInteger("Attack", 0);
    }
}
