using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ControlLight : MonoBehaviour
{
    private const float DIVISOR_VELOCIDADE_LUZ = 10f;
    private Light2D playerLight;
    [SerializeField]
    private int velocidadeReducaoDaLuz = 50;
    [SerializeField]
    private int velocidadeDeAumentoDaLuz = 20;
    [SerializeField]
    private GameObject vidaDoPlayer;
    [SerializeField]
    private int luzMaximaInner = 4;
    [SerializeField]
    private int luzMaximaOuter = 5;
    
    private float velocidadeDeReducaoDaLuz;
    private float velocidadeAumentoDaLuz;

    private Rigidbody2D rb;

    private bool reduzindoLuz = true;
       
    void Start()
    {
        velocidadeDeReducaoDaLuz = velocidadeReducaoDaLuz/ DIVISOR_VELOCIDADE_LUZ;
        velocidadeAumentoDaLuz = velocidadeDeAumentoDaLuz / DIVISOR_VELOCIDADE_LUZ;
        playerLight = GetComponent<Light2D>();
        rb = GetComponent<Rigidbody2D>();

        playerLight.pointLightInnerRadius = luzMaximaInner;
        playerLight.pointLightOuterRadius = luzMaximaOuter;
    }
    
    void Update()
    {
        if (PlayerMoves.GameOver)
        {
            ReduzLugParaGameOver();
            return;
        }
        if(reduzindoLuz)
            ReduzLuz();
        else
            AumentaLuz();

        if (InnerLimiteInferior() && OuterLimiteInferior())
        {
            PlayerMoves.GameOver = true;
            vidaDoPlayer.SetActive(false);
            rb.bodyType = RigidbodyType2D.Static;
            FindObjectOfType<PlayerLife>().MostraMenuGameOver();
        }
    }

    private void ReduzLuz()
    {
        if(!InnerLimiteInferior()){
            playerLight.pointLightInnerRadius -= velocidadeDeReducaoDaLuz * Time.deltaTime;
        }
        else
        {
            playerLight.pointLightOuterRadius -= velocidadeDeReducaoDaLuz * Time.deltaTime;
        }
    }

    private void ReduzLugParaGameOver()
    {
        if(playerLight.pointLightInnerRadius > 0)
            playerLight.pointLightInnerRadius -= velocidadeDeReducaoDaLuz * Time.deltaTime;
        if(playerLight.pointLightOuterRadius > 0)
            playerLight.pointLightOuterRadius -= velocidadeDeReducaoDaLuz * Time.deltaTime;
    }

    private void AumentaLuz(){
        if(InnerLimiteSupeior())
            playerLight.pointLightInnerRadius += velocidadeAumentoDaLuz * Time.deltaTime;
        if(OuterLimiteSuperior())
            playerLight.pointLightOuterRadius += velocidadeAumentoDaLuz * Time.deltaTime;        
    }

    private bool InnerLimiteSupeior(){
        return playerLight.pointLightInnerRadius <= luzMaximaInner;
    }

    private bool OuterLimiteSuperior(){
        return playerLight.pointLightOuterRadius <= luzMaximaOuter;
    }

    private bool InnerLimiteInferior(){
        return playerLight.pointLightInnerRadius <= 0;
    }

    private bool OuterLimiteInferior()
    {
        return playerLight.pointLightOuterRadius <= 0;
    }

    public void IniciaRecargaDaLuz()
    {
        reduzindoLuz = false;
    }

    public void ParaRecargaDaLuz(){
        reduzindoLuz = true;
    }

    public void ApagaLuzParaGameOver()
    {
        reduzindoLuz = true;
        velocidadeDeReducaoDaLuz = 2.0f;
    }
}
