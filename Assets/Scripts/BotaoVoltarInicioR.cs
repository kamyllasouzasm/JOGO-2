using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoVoltarInicioR : MonoBehaviour
{
    public string nomeCenaInicio = "Inicio"; 

    public void IrParaInicio()
    {
        SceneManager.LoadScene(nomeCenaInicio);
    }
}
