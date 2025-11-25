using UnityEngine;
using UnityEngine.SceneManagement;

public class MascoteClick : MonoBehaviour
{
    public MascoteData data;      
    public ScreenFader fader;     
    public string consultorioSceneName = "Consultorio";

    void OnMouseDown()
    {
        
        GameSession.I.selectedMascot = data;

        
        StartCoroutine(LoadConsultorio());
    }

    System.Collections.IEnumerator LoadConsultorio()
    {
        
        if (fader != null)
            yield return fader.FadeTo(1f, 0.4f);

       
        SceneManager.LoadScene(consultorioSceneName);
    }
}