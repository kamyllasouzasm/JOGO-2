using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    
    public void IrParaClinica()
    {
        SceneManager.LoadScene("SalaEspera");
    }

    
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