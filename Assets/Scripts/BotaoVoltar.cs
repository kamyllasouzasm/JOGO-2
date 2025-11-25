using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoVoltar : MonoBehaviour
{
   
    public string nomeCena = "SalaDeEspera";

    public void Voltar()
    {
        SceneManager.LoadScene(nomeCena);
    }
}

