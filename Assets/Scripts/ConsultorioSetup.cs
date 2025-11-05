using UnityEngine;
using System.Collections;

public class ConsultorioSetup : MonoBehaviour
{
    public Transform mascoteRoot;
    public ScreenFader fader;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);

        // Limpa o root
        foreach (Transform child in mascoteRoot)
        {
            Destroy(child.gameObject);
        }

        var data = GameSession.I != null ? GameSession.I.selectedMascot : null;
        if (data == null)
        {
            Debug.LogWarning("Nenhum mascote selecionado em GameSession");
            yield break;
        }
// *** ADICIONE ISSO PARA DEBUGAR:
        Debug.Log($"[ConsultorioSetup] selectedMascot name = '{data.name}'   prefabExame = {data.prefabExame}");
        
        // Instancia mascote
        GameObject mascote = Instantiate(data.prefabExame, mascoteRoot);
        mascote.transform.localPosition = Vector3.zero;
        mascote.transform.localRotation = Quaternion.identity;
        mascote.transform.localScale = Vector3.one;
        

        // Ajuste de posição e escala específicos
        if (data.name.Contains("Leao"))
        {
            mascote.transform.localPosition = new Vector3(0f, -0.7f, 0f);
            mascote.transform.localScale = new Vector3(2.3f, 2.3f, 2.3f);
        }

        else if (data.name.Contains("Hipopotamo"))
        {
            mascote.transform.localPosition = new Vector3(0f, -0.55f, 0f);
            mascote.transform.localScale = new Vector3(1.47f, 1.47f, 1.47f);
        }

        // Garante dentes como filho do mascote
        if (data.prefabDentes != null)
        {
            GameObject dentes = Instantiate(data.prefabDentes, mascote.transform);
            dentes.transform.localPosition = Vector3.zero;
            dentes.transform.localRotation = Quaternion.identity;
            dentes.transform.localScale = Vector3.one;
        }

        if (fader != null)
            yield return fader.FadeTo(0f, 0.5f);
    }
}


