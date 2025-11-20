using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalLimpeza : MonoBehaviour
{
    public GameObject telaParabens; // painel da tela de parabéns

    // chama quando terminar de limpar
    public void MostrarParabens()
    {
        telaParabens.SetActive(true);
    }

    // botão para voltar à sala de espera
    public void VoltarParaSala()
    {
        SceneManager.LoadScene("SalaDeEspera");
    }
}

