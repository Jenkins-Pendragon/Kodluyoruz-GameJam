using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class OrderTimeController : MonoBehaviour
{
    public GameObject orderSliderGo;
    public Slider orderSlider;
    private Tween customTween;
    private void OnEnable()
    {
        EventManager.OnGameStarted.AddListener(EnableOrderSlider);
        EventManager.OnOrderGenerated.AddListener(StartOrderTimer);
        EventManager.OnItemsPacked.AddListener(DisableOrderSlider);        
    }

    private void OnDisable()
    {
        EventManager.OnGameStarted.RemoveListener(EnableOrderSlider);
        EventManager.OnOrderGenerated.RemoveListener(StartOrderTimer);
        EventManager.OnItemsPacked.RemoveListener(DisableOrderSlider);              
    }

    private void EnableOrderSlider() 
    {
        orderSliderGo.SetActive(true);
    }

    private void DisableOrderSlider()
    {   
        customTween.Kill();        
    }
    private void StartOrderTimer() 
    {        
        float orderTime = LevelManager.Instance.CurrentLevel.orderTime;
        orderSlider.value = 1;        
        customTween = DOTween.To(() => orderSlider.value, (a) => orderSlider.value = a, 0, orderTime).OnComplete(()=>
        {
            EventManager.OnOrderFailed.Invoke();
        });
    }

    
}
