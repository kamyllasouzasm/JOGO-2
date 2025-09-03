using UnityEngine;

public enum TipoFerramenta { Escova, Fio, Sugador }

[RequireComponent(typeof(Collider2D))]
public class Ferramenta : MonoBehaviour
{
    public TipoFerramenta tipo = TipoFerramenta.Escova;
    public Transform ponta;                // arraste o filho "Ponta" no Inspector
    public float forcaLimpeza = 0.9f;      // quanto limpa por segundo

    bool segurando;
    Vector3 diferencaMouse;
    SpriteRenderer imagem; 
    int ordemOriginal;

    void Start()
    {
        imagem = GetComponent<SpriteRenderer>();
        if (imagem != null) ordemOriginal = imagem.sortingOrder;
        if (ponta == null) ponta = transform;
    }

    void OnMouseDown()
    {
        segurando = true;
        var mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        diferencaMouse = transform.position - new Vector3(mouse.x, mouse.y, 0);
        if (imagem) imagem.sortingOrder = 100; // fica na frente
    }

    void OnMouseUp()
    {
        segurando = false;
        if (imagem) imagem.sortingOrder = ordemOriginal;
    }

    void Update()
    {
        if (!segurando) return;

        var mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mouse.x, mouse.y, 0) + diferencaMouse;

        // Verifica sujeiras embaixo da ponta
        var acertos = Physics2D.OverlapPointAll(ponta.position);
        float qtd = forcaLimpeza * Time.deltaTime;

        foreach (var a in acertos)
        {
            var sujeira = a.GetComponent<Sujeira>();
            if (sujeira != null)
                sujeira.Limpar(qtd, tipo);
        }
    }
}

