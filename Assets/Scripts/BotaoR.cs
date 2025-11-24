using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoVoltarR : MonoBehaviour
{
    public string nomeCenaSalaEspera = "SalaEspera";

    public void VoltarParaSala()
    {
        SceneManager.LoadScene(nomeCenaSalaEspera);
    }
}
