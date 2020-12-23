using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappinessBarController : MonoBehaviour
{

    [SerializeField] private Image happinessBarImage;
    [SerializeField] private Image happinessBarOutImage;
    [SerializeField] private int happinessAmount;
    private int happinessTotal = 100; 
    private float targetHappiness, currentHappiness=10f;

    private void Start()
    {
        UpdateHappinesBar();
    }
    public void IncreaseHappinessButton()
    {
        StartCoroutine(IncreaseHappiness());
    }
    public void DecreaseHappinessButton()
    {
        StartCoroutine(DecreaseHappiness());
    }
    IEnumerator IncreaseHappiness()
    {
        targetHappiness = currentHappiness + happinessAmount;
        while (currentHappiness < targetHappiness)
        {
            currentHappiness+=0.5f;
            if (currentHappiness>=100)
            {
                currentHappiness = 100;
            }
            UpdateHappinesBar();
            yield return new WaitForSeconds(0.02f);
        }

    }
    IEnumerator DecreaseHappiness()
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
        float ratio = currentHappiness / happinessTotal;
        happinessBarImage.fillAmount = ratio;
        if (ratio>=1)
        {
            happinessBarImage.color = Color.green;
        }
        else if (ratio<=0)
        {
            happinessBarOutImage.color = Color.red;
        }
    }
}
