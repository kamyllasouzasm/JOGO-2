using UnityEngine;
using System.Collections;

public class ConsultorioSetup : MonoBehaviour
{
    public SpriteRenderer mascotRenderer; // Mascote na cena
    public ScreenFader fader;             // Tela preta para fade

    private IEnumerator Start()
    {
        // Mostra o mascote escolhido
        if (GameSession.I != null && GameSession.I.selectedMascot != null)
        {
            var data = GameSession.I.selectedMascot;

            mascotRenderer.sprite = data.spriteExam;

            // 🔹 Ajustar automaticamente posição e escala
            mascotRenderer.transform.localPosition = data.examPosition;
            mascotRenderer.transform.localScale = data.examScale;
        }

        // Faz o fade-in da tela preta
        if (fader != null)
            yield return fader.FadeTo(0f, 0.5f);
    }
}