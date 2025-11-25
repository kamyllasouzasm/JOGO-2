using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelecionarPersonagem : MonoBehaviour
{
    public static string personagemEscolhido;
    public Image telaPreta;     
    public float tempoFade = 0.5f;
    bool emTransicao = false;

    public void EscolherPersonagem(string nome)
    {
        if (emTransicao) return; 
        personagemEscolhido = nome;
        Debug.Log("Personagem selecionado: " + personagemEscolhido);

        
        if (telaPreta == null)
        {
           
            return;
        }

        StartCoroutine(FazerFade());
    }

    System.Collections.IEnumerator FazerFade()
    {
        emTransicao = true;

       
        var cor = telaPreta.color;
        cor.a = 0f;
        telaPreta.color = cor;

       
        telaPreta.raycastTarget = false;

        float t = 0f;
        while (t < tempoFade)
        {
            t += Time.deltaTime;
            cor.a = Mathf.Lerp(0f, 1f, t / tempoFade); // 0 -> 1
            telaPreta.color = cor;
            yield return null;
        }

         SceneManager.LoadScene("Consultorio2");
    }
}