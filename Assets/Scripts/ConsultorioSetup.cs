using UnityEngine;
using System.Collections;


public class ConsultorioSetup : MonoBehaviour
{
    public Transform mascoteRoot; // arrasta MascoteRoot na cena
    public ScreenFader fader; // arrasta ScreenFader do Canvas


    private IEnumerator Start()
    {
        var data = GameSession.I != null ? GameSession.I.selectedMascot : null;
        if (data == null)
        {
            Debug.LogWarning("Nenhum Mascote selecionado em GameSession");
            yield break;
        }


        // Instancia sem definir parent direto (às vezes evita problemas de escala)
        GameObject mascote = Instantiate(data.prefabExame) as GameObject;
        if (mascote == null)
        {
            Debug.LogError("Erro: prefabExame não é GameObject válido");
            yield break;
        }


        // coloca o mascote como filho do mascoteRoot (worldPositionStays = false preserva a posição local que setarmos)
        mascote.transform.SetParent(mascoteRoot, false);


        // definir posição / escala / rotação explicitamente em local space
        // se data.examPosition/examScale estiverem ok, usa; senão usa fallback
        // --- Definindo posição e escala manualmente por mascote ---
        Vector3 pos = default;
        Vector3 scl = default;


        if (data.name.Contains("Leao"))
        {
            pos = new Vector3(0f, -1.5f, 0f); // posição Leão
            scl = new Vector3(2.978422f, 2.978422f, 2.978422f); // escala Leão
        }
        else if (data.name.Contains("Hipopotamo"))
        {
            pos = new Vector3(0f, -0.55f, 0f); // posição Hipopótamo
            scl = new Vector3(1.470711f, 1.470711f, 1.470711f); // escala Hipopótamo
        }



// aplica
        mascote.transform.localPosition = pos;
        mascote.transform.localScale = scl;
        mascote.transform.localRotation = Quaternion.identity;




        // se houver dentes, instancia como filho do próprio mascote (assim fica no lugar certo)
        // if (data.prefabDentes != null)
//     Instantiate(data.prefabDentes, mascote.transform, false);


        // fade-in
        if (fader != null)
            yield return fader.FadeTo(0f, 0.5f);
    }
}

