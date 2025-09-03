using UnityEngine;

public class Dente : MonoBehaviour
{
    private int sujeirasRestantes;

    void Start()
    {
        // Conta quantas sujeiras existem dentro desse dente
        sujeirasRestantes = GetComponentsInChildren<Sujeira>(true).Length;
    }

    // Chamado quando uma sujeira é removida
    public void AvisarSujeiraSaiu()
    {
        sujeirasRestantes--;
        if (sujeirasRestantes <= 0)
        {
            if (GerenteJogo.Instancia != null)
            {
                GerenteJogo.Instancia.AvisarDenteLimpou();
            }
        }
    }
}





