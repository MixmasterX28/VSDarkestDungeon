using UnityEngine;
using UnityEngine.EventSystems;

public class OnMouseHoverUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject UIpart;

    private void Start() // zorgt ervoor dat het UIpart gelijk uit is
    {
        UIpart.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData) // OnPointer gebruikt omdat de onMouseEnter niet werkte vanwege de camera
    {
        UIpart.SetActive(true);
        Debug.Log("Pointer entered UI element");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIpart.SetActive(false);
        Debug.Log("Pointer exited UI element");
    }
}