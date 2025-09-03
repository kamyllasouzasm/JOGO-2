using UnityEngine;

public enum TipoSujeira { Placa, EntreDente, Baba }

public class Sujeira : MonoBehaviour
{
    public TipoSujeira tipo = TipoSujeira.Placa;
    [Range(0.2f, 2f)] public float resistencia = 1f; // 1 = muito sujo, 0 = limpo

    SpriteRenderer imagem;
    Dente dentePai;

    void Awake()
    {
        imagem = GetComponent<SpriteRenderer>();
        dentePai = GetComponentInParent<Dente>();
    }

    // Quando a ferramenta encosta, tenta limpar
    public void Limpar(float quanto, TipoFerramenta ferramenta)
    {
        if (!FerramentaCorreta(ferramenta)) return;

        resistencia -= quanto;
        resistencia = Mathf.Clamp01(resistencia);

        // Vai sumindo da tela
        var cor = imagem.color;
        cor.a = resistencia;
        imagem.color = cor;

        if (resistencia <= 0f)
        {
            dentePai?.AvisarSujeiraSaiu();
            Destroy(gameObject);
        }
    }

    bool FerramentaCorreta(TipoFerramenta f)
    {
        if (tipo == TipoSujeira.Placa)       return f == TipoFerramenta.Escova;
        if (tipo == TipoSujeira.EntreDente)  return f == TipoFerramenta.Fio;
        if (tipo == TipoSujeira.Baba)        return f == TipoFerramenta.Sugador;
        return false;
    }
}