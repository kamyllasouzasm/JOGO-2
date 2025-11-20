using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenteJogo : MonoBehaviour
{
    public static GerenteJogo Instancia;
    int dentesLimpos = 0;
    public int quantidadeTotalSujeiras = 0;

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
            SceneManager.LoadScene("VictoryScene");
        }
    }
}


