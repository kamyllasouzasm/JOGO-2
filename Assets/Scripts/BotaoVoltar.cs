using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoVoltar : MonoBehaviour
{
    // Nome da cena para voltar
    public string nomeCena = "SalaDeEspera";

    public void Voltar()
    {
        SceneManager.LoadScene(nomeCena);
    }
}

