using UnityEngine;

public class NPCPatrulha : MonoBehaviour
{
    [Header("Patrulha")]
    public float velocidade = 2f;
    public float distanciaPatrulha = 4f; // Distância total (ida + volta)

    private Vector3 pontoInicial;
    private Vector3 pontoFinal;
    private Vector3 alvoAtual;
    private bool indoParaDireita = true;

    private void Start()
    {
        pontoInicial = transform.position;
        pontoFinal = pontoInicial + Vector3.right * distanciaPatrulha;
        alvoAtual = pontoFinal;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, alvoAtual, velocidade * Time.deltaTime);

        if (Vector3.Distance(transform.position, alvoAtual) < 0.1f)
        {
            indoParaDireita = !indoParaDireita;
            alvoAtual = indoParaDireita ? pontoFinal : pontoInicial;
            VirarSprite();
        }
    }

    private void VirarSprite()
    {
        Vector3 escala = transform.localScale;
        escala.x = indoParaDireita ? Mathf.Abs(escala.x) : -Mathf.Abs(escala.x);
        transform.localScale = escala;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}