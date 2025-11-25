using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalLimpeza : MonoBehaviour
{
    public GameObject telaParabens; 

    
    public void MostrarParabens()
    {
        TextoParabens.SetActive(true);
    }

    
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

