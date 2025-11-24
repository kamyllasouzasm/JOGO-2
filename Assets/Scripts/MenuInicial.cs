using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    // Chamado ao clicar no botão "Clínica dos Bichinhos"
    public void IrParaClinica()
    {
        SceneManager.LoadScene("SalaEspera");
    }

    // Chamado ao clicar no botão "Sorriso dos Bichinhos"
    public void IrParaSorriso()
    {
        SceneManager.LoadScene("SalaDeEspera"); 
    }

    public void IrCapa1()
    {
        SceneManager.LoadScene("capa");
    }
    
    public void IrTelaInicial()
    {
        SceneManager.LoadScene("TelaInicial");
    }

}