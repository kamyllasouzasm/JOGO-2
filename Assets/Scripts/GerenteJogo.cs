using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenteJogo : MonoBehaviour
{
    public static GerenteJogo Instancia;
    int dentesLimpos = 0;
    public int quantidadeTotalSujeiras = 0;
    public GameObject confeteImagem;


    void Awake()
    {
        Instancia = this;
    }

    // Chamada quando um dente fica limpo
    public void AvisarDenteLimpou()
    {
        dentesLimpos++;

        if (dentesLimpos >= quantidadeTotalSujeiras)
        {
            FinalLimpeza();
        }
    }
    
    public GameObject textoParabens; // arraste no Inspector

    void FinalLimpeza()
    {
        if (textoParabens != null)
            textoParabens.SetActive(true);

        if (confeteImagem != null)
            confeteImagem.SetActive(true);
    }


}


