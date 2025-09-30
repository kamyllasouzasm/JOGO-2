using UnityEngine;
using System.Collections;

public class ConsultorioSetup : MonoBehaviour
{
    public Transform mascoteRoot; // objeto vazio onde o mascote vai aparecer
    public ScreenFader fader;     // tela preta para o fade

    IEnumerator Start()
    {
        // pega o mascote escolhido na sala de espera
        MascoteData data = GameSession.I != null ? GameSession.I.selectedMascot : null;

        if (data != null)
        {
            // apaga qualquer coisa que já estava no mascoteRoot
            foreach (Transform filho in mascoteRoot)
            {
                Destroy(filho.gameObject);
            }

            // coloca o mascote na cena
            GameObject mascote = Instantiate(data.prefabExame, mascoteRoot);
            mascote.transform.localPosition = data.examPosition;
            mascote.transform.localScale = data.examScale;

            // coloca os dentes se tiver
            if (data.prefabDentes != null)
            {
                Instantiate(data.prefabDentes, mascoteRoot);
            }
        }

        // tira a tela preta (fade-in)
        if (fader != null)
            yield return fader.FadeTo(0f, 0.5f);
    }
}