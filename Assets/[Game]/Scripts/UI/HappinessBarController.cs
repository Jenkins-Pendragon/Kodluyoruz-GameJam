using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HappinessBarController : MonoBehaviour
{

    public Image happinessBarImage;
    public Image happinessBarOutImage;
    public float happinessAmount; //Check To Do

    private float happinessTotal = 0;
    private float HappinessTotal 
    { 
        get 
        { 
            if(happinessTotal == 0) 
            {
                happinessTotal = LevelManager.Instance.CurrentLevel.happinessTotal;
            }
            return happinessTotal;
        } 
    }
    private float targetHappiness, currentHappiness=10f;

    private void OnEnable()
    {
        EventManager.OnOrderDelivered.AddListener(IncreaseHappiness);
        EventManager.OnOrderFailed.AddListener(DecreaseHappiness);
    }

    private void OnDisable()
    {
        EventManager.OnOrderDelivered.RemoveListener(IncreaseHappiness);
        EventManager.OnOrderFailed.RemoveListener(DecreaseHappiness);
    }

    private void Start()
    {
        UpdateHappinesBar();
    }

    public void IncreaseHappiness() 
    {
        currentHappiness += happinessAmount;
        UpdateHappinesBar();
        if (currentHappiness>= HappinessTotal)
        {
            EventManager.OnLevelSuccesed.Invoke();
        }
        else
        {
            
        }
    }

    public void DecreaseHappiness() 
    {
        StartCoroutine(DecreaseHappinessCo());
    }
    IEnumerator IncreaseHappinessCo()
    {
        targetHappiness = currentHappiness + happinessAmount;
        while (currentHappiness < targetHappiness)
        {
            currentHappiness+=0.5f;
            if (currentHappiness>= HappinessTotal)
            {
                currentHappiness = 100;
            }
            UpdateHappinesBar();
            yield return new WaitForSeconds(0.02f);
        }

    }
    IEnumerator DecreaseHappinessCo()
    {
        targetHappiness = currentHappiness - happinessAmount;
        while (currentHappiness > targetHappiness)
        {
            currentHappiness -= 0.5f;
            if (currentHappiness <= 0)
            {
                currentHappiness = 0;
            }
            UpdateHappinesBar();
            yield return new WaitForSeconds(0.02f);
        }

    }
    
    private void UpdateHappinesBar()
    {        
        float ratio = currentHappiness / HappinessTotal;
        DOTween.To(() => happinessBarImage.fillAmount, (a) => happinessBarImage.fillAmount = a, ratio, 2f).
            OnComplete(()=> {
                if (ratio >= 1) happinessBarImage.color = Color.green;               
                else if (ratio <= 0) happinessBarOutImage.color = Color.red;                
            });
    }
}
