using UnityEngine;

public class Dente : MonoBehaviour
{
    private int sujeirasRestantes;
    

    void Start()
    {
        
        sujeirasRestantes = GetComponentsInChildren<Sujeira>(true).Length;
    }

   
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





