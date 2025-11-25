using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropTarget : MonoBehaviour, IDropHandler
{
    public ControleSaude controle; 

    public void OnDrop(PointerEventData eventData)
    {
        var item = eventData.pointerDrag?.GetComponent<ItemData>();
        if (item == null)
        {
            Debug.Log("[ItemDropTarget] OnDrop: item == null");
            return;
        }

        string tipo = (item.tipo ?? "").ToLower().Trim();
        Debug.Log("[ItemDropTarget] Item solto: tipo=" + tipo + " valor=" + item.valor);

        if (controle == null)
        {
            Debug.LogError("[ItemDropTarget] controle NÃO está atribuído no Inspector!");
            Destroy(item.gameObject);
            return;
        }

       
        controle.AumentarSaude(item.valor);

        
        if (tipo == "injecao")
            controle.AplicarInjecao();      
        else if (tipo == "curativo")
            controle.AplicarCurativo();    
        else if (tipo == "termometro")
            controle.AplicarTermometro();  
        else
            Debug.LogWarning("[ItemDropTarget] tipo não reconhecido: " + item.tipo);

        
        Destroy(item.gameObject);
    }
}
