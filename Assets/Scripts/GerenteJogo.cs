using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenteJogo : MonoBehaviour
{
    public static GerenteJogo Instancia;

    int totalDentes;
    int dentesLimpinhos;

    void Awake()
    {
        if (Instancia != null && Instancia != this) { Destroy(gameObject); return; }
        Instancia = this;
    }

    void Start()
    {
        totalDentes = FindObjectsOfType<Dente>().Length;
        dentesLimpinhos = 0;
    }

    public void AvisarDenteLimpou()
    {
        dentesLimpinhos++;
        if (dentesLimpinhos >= totalDentes)
        {
            // quando todos os dentes estão limpos, troca de cena
            SceneManager.LoadScene("VictoryScene");
        }
    }
}

