using UnityEngine;
using System.Collections;

public class ConsultorioSetup : MonoBehaviour
{
    public Transform mascoteRoot;   // Arraste o MascoteRoot da cena
    public ScreenFader fader;       // Arraste o ScreenFader do Canvas

    private IEnumerator Start()
    {
        // Pega o mascote escolhido
        var data = GameSession.I != null ? GameSession.I.selectedMascot : null;
        if (data != null)
        {
            // Instancia o prefab certo (hipo ou leão) dentro do MascoteRoot
            Instantiate(data.prefabExame, mascoteRoot);
        }

        // Faz o fade-in (tela preta → cena visível)
        if (fader != null)
            yield return fader.FadeTo(0f, 0.5f);
    }
}