using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoVoltarInicioR : MonoBehaviour
{
    public string nomeCenaInicio = "Inicio";  // coloque exatamente o nome da sua cena inicial

    public void IrParaInicio()
    {
        SceneManager.LoadScene(nomeCenaInicio);
    }
}
