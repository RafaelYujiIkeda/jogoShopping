using UnityEngine;

public class GerarNPC : MonoBehaviour
{
    [Header("Configurações")]
    public GameObject modeloNPC;
    public float tempoParaGerar = 3f;

    private float cronometro;

    private void Awake()
    {
        cronometro = tempoParaGerar;
    }

    void Update()
    {
        if (modeloNPC == null)
        {
            Debug.LogWarning("Modelo NPC não atribuído!");
            return;
        }

        cronometro -= Time.deltaTime;
        if (cronometro <= 0f)
        {
            GerarNovoNPC();
            cronometro = tempoParaGerar;
        }
    }

    void GerarNovoNPC()
    {
        GameObject npc = Instantiate(modeloNPC, transform.position, Quaternion.identity);

        // Garante que tenha SpriteRenderer
        SpriteRenderer sr = npc.GetComponent<SpriteRenderer>();
        if (sr == null)
            sr = npc.AddComponent<SpriteRenderer>();

        // Se não tiver sprite, cria um quadrado ciano
        if (sr.sprite == null)
        {
            Texture2D tex = new Texture2D(1, 1);
            tex.SetPixel(0, 0, Color.cyan);
            tex.Apply();
            sr.sprite = Sprite.Create(tex, new Rect(0, 0, 1, 1), new Vector2(0.5f, 0.5f));
            npc.transform.localScale = new Vector3(2, 2, 1);
        }
    }
}