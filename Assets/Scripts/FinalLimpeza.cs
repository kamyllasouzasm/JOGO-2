using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalLimpeza : MonoBehaviour
{
    public GameObject telaParabens; // painel da tela de parabéns

    // chama quando terminar de limpar
    public void MostrarParabens()
    {
        TextoParabens.SetActive(true);
    }

    // botão para voltar à sala de espera
    public void VoltarParaSala()
    {
        SceneManager.LoadScene("SalaDeEspera");
    }
}

public class TextoParabens
{
    public static void SetActive(bool b)
    {
        throw new System.NotImplementedException();
    }
}

