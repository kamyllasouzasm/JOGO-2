using UnityEngine;
using System.Collections;

public class ConsultorioSetup : MonoBehaviour
{
    public Transform mascoteRoot; // arraste o objeto MascoteRoot da cena
    public ScreenFader fader;     // arraste o ScreenFader do Canvas

    private IEnumerator Start()
    {
        var data = GameSession.I != null ? GameSession.I.selectedMascot : null;

        if (data != null && data.prefabExame != null)
        {
            // Instancia o mascote escolhido
            GameObject mascote = (GameObject)Instantiate(data.prefabExame, mascoteRoot);



            // Define posição e escala do exame
            mascote.transform.localPosition = data.examPosition;
            mascote.transform.localScale = data.examScale;

            // Instancia os dentes, se existir
            if (data.prefabDentes != null)
                Instantiate(data.prefabDentes, mascoteRoot);
        }
        else
        {
            Debug.LogError("⚠️ MascoteData não configurado corretamente!");
        }

        // Faz o fade-in da tela
        if (fader != null)
            yield return fader.FadeTo(0f, 0.5f);
    }
}