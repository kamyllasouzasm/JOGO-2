using UnityEngine;
using System.Collections;

public class ConsultorioSetup : MonoBehaviour
{
    public Transform mascoteRoot;   // arraste o MascoteRoot da cena aqui
    public ScreenFader fader;       // arraste o ScreenFader do Canvas
    public GameObject dentesHipopotamo; 
    public GameObject dentesLeao;

    private IEnumerator Start()
    {
        // Pega qual mascote foi escolhido
        var data = GameSession.I != null ? GameSession.I.selectedMascot : null;
        if (data != null)
        {
            // Mostra o mascote certo com a boca aberta
            var img = mascoteRoot.gameObject.AddComponent<SpriteRenderer>();
            img.sprite = data.spriteExam; 

            // Instancia os dentes corretos
            if (data.nome == "Hipopotamo" && dentesHipopotamo != null)
                Instantiate(dentesHipopotamo, mascoteRoot);
            else if (data.nome == "Leao" && dentesLeao != null)
                Instantiate(dentesLeao, mascoteRoot);
        }

        // Faz o fade-in (abre a tela escura)
        if (fader != null)
            yield return fader.FadeTo(0f, 0.5f);
    }
}