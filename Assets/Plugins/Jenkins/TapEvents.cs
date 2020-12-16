using UnityEngine;
using UnityEngine.EventSystems;
public class TapEvents : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        EventManager.OnTapStart.Invoke();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        EventManager.OnTapRelease.Invoke();
    }
}