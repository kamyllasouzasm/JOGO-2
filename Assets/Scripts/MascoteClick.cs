using UnityEngine;
using UnityEngine.SceneManagement;

public class MascoteClick : MonoBehaviour
{
    public MascoteData data;      
    public ScreenFader fader;     
    public string consultorioSceneName = "Consultorio";

    void OnMouseDown()
    {
        // guarda o mascote escolhido
        GameSession.I.selectedMascot = data;

        // inicia a troca de cena
        StartCoroutine(LoadConsultorio());
    }

    System.Collections.IEnumerator LoadConsultorio()
    {
        // se tiver fader, faz o fade
        if (fader != null)
            yield return fader.FadeTo(1f, 0.4f);

        // carrega o consultório
        SceneManager.LoadScene(consultorioSceneName);
    }
}