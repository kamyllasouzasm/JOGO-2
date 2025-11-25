using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class ItemDragUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Canvas canvas;              
    RectTransform rt;
    CanvasGroup cg;
    Vector2 inicioAnchored;

    void Awake()
    {
        rt = GetComponent<RectTransform>();
        cg = gameObject.GetComponent<CanvasGroup>();
        if (cg == null) cg = gameObject.AddComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        inicioAnchored = rt.anchoredPosition;
        cg.blocksRaycasts = false; 
        Debug.Log(name + " BeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        RectTransform canvasRect = canvas.transform as RectTransform;
        
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, eventData.position, canvas.worldCamera, out pos);
        rt.anchoredPosition = pos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        cg.blocksRaycasts = true;
        
        if (eventData.pointerEnter == null || eventData.pointerEnter.GetComponentInParent<ItemDropTarget>() == null)
        {
            rt.anchoredPosition = inicioAnchored;
            Debug.Log(name + " voltou para o inicio");
        }
        else
        {
            Debug.Log(name + " dropado em " + eventData.pointerEnter.name);
        }
    }
}
