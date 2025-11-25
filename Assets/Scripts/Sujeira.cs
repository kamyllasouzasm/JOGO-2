using UnityEngine;

public enum TipoSujeira { Placa, EntreDente, Baba }

public class Sujeira : MonoBehaviour
{
    public TipoSujeira tipo = TipoSujeira.Placa;
    [Range(0.2f, 2f)] public float resistencia = 1f; 
    

    SpriteRenderer imagem;
    Dente dentePai;

    void Awake()
    {
        imagem = GetComponent<SpriteRenderer>();
        dentePai = GetComponentInParent<Dente>();
    }

    
    public void Limpar(float quanto, TipoFerramenta ferramenta)
    {
        if (!FerramentaCorreta(ferramenta)) return;

        resistencia -= quanto;
        resistencia = Mathf.Clamp01(resistencia);

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