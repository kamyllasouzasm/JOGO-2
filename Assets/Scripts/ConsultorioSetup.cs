using UnityEngine;
using System.Collections;

public class ConsultorioSetup : MonoBehaviour
{
    public Transform mascoteRoot;
    public ScreenFader fader;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);
        

        var data = GameSession.I != null ? GameSession.I.selectedMascot : null;
        if (data == null)
        {
            Debug.LogWarning("Nenhum mascote selecionado em GameSession");
            yield break;
        }

        Debug.Log($"[ConsultorioSetup] selectedMascot name = '{data.name}'   prefabExame = {data.prefabExame}");
        
        
        mascoteRoot.transform.localPosition = Vector3.zero;
        mascoteRoot.transform.localRotation = Quaternion.identity;
        
        
        GameObject dentes = Instantiate(data.prefabDentes, mascoteRoot.transform);
        
        
        if (data.prefabDentes != null)
        {
            dentes.transform.localPosition = Vector3.zero;
            dentes.transform.localRotation = Quaternion.identity;
            
        }
        
        
        if (data.name.Contains("Leao"))
        {
            mascoteRoot.transform.localPosition = new Vector3(0f, -0.7f, 0f);
            
        }

        else if (data.name.Contains("Hipopotamo"))
        {
            mascoteRoot.transform.localPosition = new Vector3(0f, -0.55f, 0f);
           
        }

   
        if (fader != null)
            yield return fader.FadeTo(0f, 0.5f);
    }
}


