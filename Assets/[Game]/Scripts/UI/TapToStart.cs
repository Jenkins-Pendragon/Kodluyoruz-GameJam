using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class TapToStart : MonoBehaviour, IPointerDownHandler
{
    public TextMeshProUGUI tapToStart;
    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.Instance.StartGame();
        tapToStart.enabled = false;
        Destroy(this);
    }
}
