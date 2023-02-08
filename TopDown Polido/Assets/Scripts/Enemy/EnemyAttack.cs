
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Animator animator;
    public EstadosData state;

    [SerializeField]
    private float danoDoInimigo = 0.7f;
    [SerializeField]
    private int LayerPlayer = 3;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float distanciaAtaque = 1.5f;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (PlayerEstaDentroAreaDeAtaque())// && NaoEAnimacaoDeAtaque())
        {
            AtacarPlayer();
        }
    }

    private bool PlayerEstaDentroAreaDeAtaque()
    {
        var posicaoInimigo = new Vector2(transform.position.x, transform.position.y);
        var posicaoPlayer = new Vector2(player.transform.position.x, player.transform.position.y);

        var p3 = posicaoInimigo - posicaoPlayer;

        RaycastHit2D hit = Physics2D.Raycast(posicaoInimigo, p3.normalized, distanciaAtaque, LayerMask.GetMask("Player"));
        //Debug.DrawLine(posicaoInimigo, Vector3.Distance(transform.position, player.transform.position), Color.blue);

        //Debug.DrawLine(posicaoInimigo, posicaoPlayer, Color.red);

        //Debug.Log("Hit tag: " + hit.collider.name);
        //if (hit.collider != null)
        //    return hit.collider.tag.Equals("Player");
        //return false;
        var distanciaPlayer = Vector3.Distance(transform.position, player.transform.position);
        //Debug.Log("Distancia player: " + distanciaPlayer);
        return distanciaPlayer <= distanciaAtaque;
    }

    private bool NaoEAnimacaoDeAtaque()
    {
        var anim = animator.GetCurrentAnimatorStateInfo(0).IsName("inimigo_verde_attack");
        return !anim;
    }

    private void AtacarPlayer()
    {
        state = EstadosData.Attack;
        animator.SetInteger("estado", (int)state);
        PlayerLife pl = player.GetComponent<PlayerLife>();

        if (!pl.invulneravel)
        {
            
            soundFX.playSound(sound.ATTACK_GREEN);
            pl.ReceberDano(danoDoInimigo);
        }
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (ColidiuComOPlayer(other))
    //    {
    //        if (PodeAtacarPlayer(other.gameObject))
    //        {
    //            AtacarPlayer(other.gameObject);
    //        }
    //    }
    //}

    //private bool ColidiuComOPlayer(Collider2D other)
    //{
    //    return "Player".Equals(other.tag);
    //}

    //private bool PodeAtacarPlayer(GameObject player) {
    //    var playerVisivel = PlayerEstaVisivel(player);
    //    var inimigoAtacandoPlayer = InimigoEstaAtacandoPlayer();
    //    Debug.Log(playerVisivel);
    //    return playerVisivel || inimigoAtacandoPlayer;    
    //        }

    //void OnTriggerStay2D(Collider2D other)
    //{
    //    if (ColidiuComOPlayer(other))
    //    {
    //        if (PodeAtacarPlayer(other.gameObject))
    //        {
    //            AtacarPlayer(other.gameObject);
    //        }
    //    }
    //}

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    state = EstadosData.Idle;
    //    animator.SetInteger("estado", (int)state);
    //}

    //private bool PlayerEstaVisivel(GameObject player)
    //{
    //    RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position, Vector2.Distance(transform.position, player.transform.position),3);
    //    if (hit.collider != null)
    //        return (LayerPlayer & (1 << hit.collider.gameObject.layer)) != 0;

    //    return false;
    //    //var naoExisteNada = hit.collider == null;
    //    //return naoExisteNada;
    //}

    //private bool InimigoEstaAtacandoPlayer()
    //{
    //    return animator.GetCurrentAnimatorStateInfo((int)EstadosData.Attack).IsName("inimigo_verde_attack") &&
    //        animator.GetCurrentAnimatorStateInfo((int)EstadosData.Attack).normalizedTime < 1.0f;
    //}

    //private void ChecarAlvoVisivel()
    //{
    //    var resultado = Physics2D.Raycast(transform.position, Alvo.position - transform.position, raioDeVisao, visivelLM);
    //    if (resultado.collider != null)
    //    {
    //        return (playerLM & (1 << resultado.collider.gameObject.layer)) != 0;
    //    }
    //    return false;
    //}
}
