using UnityEngine;

public class PlayerBasico : MonoBehaviour
{
    // Velocidade horizontal do jogador
    public float velocidade = 5f;

    // Força aplicada ao pular
    public float forcaPulo = 8f;


    // Componentes
    private Rigidbody2D rb;
    private bool estaNoChao;

    void Start()
    {
        // Pega a referência ao Rigidbody2D do jogador
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Captura o movimento horizontal (setas ou A/D)
        float movimentoX = 0f;
        float movimentoY = 0f;

        if (Input.GetKey(KeyCode.A)) movimentoX = -1f;
        if (Input.GetKey(KeyCode.D)) movimentoX = 1f;
        if (Input.GetKey(KeyCode.W)) movimentoY = 1f;
        if (Input.GetKey(KeyCode.S)) movimentoY = -1f;

        // Define a velocidade horizontal (mantém a velocidade vertical)
        rb.linearVelocity = new Vector2(movimentoX * velocidade, movimentoY * velocidade);


        // Se o jogador apertar espaço e estiver no chão, pula
        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);
        }

        // Inverte o sprite quando muda de direção (opcional)
        if (movimentoX != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(movimentoX), 1f, 1f);
        }
    }
}

    // Desenha o círculo de checagem do chão no editor (ajuda visualmente)
  