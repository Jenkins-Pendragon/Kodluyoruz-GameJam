using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class OrderTimeController : MonoBehaviour
{
    public GameObject orderSliderGo;
    public Slider orderSlider;
    private void OnEnable()
    {
        EventManager.OnOrderGenerated.AddListener(StartOrderTimer);
        EventManager.OnOrderCompleted.AddListener(DisableOrderSlider);        
    }

    private void OnDisable()
    {
        EventManager.OnOrderGenerated.RemoveListener(StartOrderTimer);
        EventManager.OnOrderCompleted.RemoveListener(DisableOrderSlider);              
    }

    private void EnableOrderSlider() 
    {
        orderSliderGo.SetActive(true);
    }

    private void DisableOrderSlider()
    {
        orderSliderGo.SetActive(false);
        DOTween.Kill(gameObject);
    }
    private void StartOrderTimer() 
    {
        EnableOrderSlider();
        float orderTime = LevelManager.Instance.CurrentLevel.orderTime;
        orderSlider.value = 1;
        DOTween.To(() => orderSlider.value, (a) => orderSlider.value = a, 0, orderTime).OnComplete(()=>
        {
            EventManager.OnOrderFailed.Invoke();
        });
    }

    
}
