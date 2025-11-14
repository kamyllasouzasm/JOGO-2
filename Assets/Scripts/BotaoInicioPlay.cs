using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoInicioPlay : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SalaDeEspera");
    }
}
