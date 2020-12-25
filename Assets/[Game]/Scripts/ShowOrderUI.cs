using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using DG.Tweening;
using System;

public class ShowOrderUI : MonoBehaviour
{

    public List<Image> Size1Images = new List<Image>();
    public List<Image> Size2Images = new List<Image>();
    public List<Image> Size3Images = new List<Image>();
    public List<Image> Size4Images = new List<Image>();
    public List<GameObject> imageParents = new List<GameObject>();


    private void OnEnable()
    {
        EventManager.OnOrderGenerated.AddListener(ShowOrderIcon);
    }

    private void OnDisable()
    {
        EventManager.OnOrderGenerated.RemoveListener(ShowOrderIcon);
    }


    public void ShowOrderIcon()
    {
        int orderCount = LevelManager.Instance.orderItems.Count;
        switch (orderCount)
        {
            case 1:
                for (int i = 0; i < orderCount; i++)
                {
                    Size1Images[i].sprite = LevelManager.Instance.orderItems.Values.ElementAt(i).toyIcon;
                    Size1Images[i].DOFade(0, 0);
                    Size1Images[i].DOFade(1, 2);
                }
                DisableParentsExcept(orderCount - 1);
                break;
                
            case 2:
                for (int i = 0; i < orderCount; i++)
                {
                    Size2Images[i].sprite = LevelManager.Instance.orderItems.Values.ElementAt(i).toyIcon;
                    Size2Images[i].DOFade(0, 0);
                    Size2Images[i].DOFade(1, 2);
                    DisableParentsExcept(orderCount - 1);
                }
                break;
            case 3:
                for (int i = 0; i < orderCount; i++)
                {
                    Size3Images[i].sprite = LevelManager.Instance.orderItems.Values.ElementAt(i).toyIcon;
                    Size3Images[i].DOFade(0, 0);
                    Size3Images[i].DOFade(1, 2);
                    DisableParentsExcept(orderCount - 1);
                }
                break;
            case 4:
                for (int i = 0; i < orderCount; i++)
                {
                    Size4Images[i].sprite = LevelManager.Instance.orderItems.Values.ElementAt(i).toyIcon;
                    Size4Images[i].DOFade(0, 0);
                    Size4Images[i].DOFade(1, 2);
                    DisableParentsExcept(orderCount - 1);
                }
                break;

            default:
                break;
        }

    }

   

    private void DisableParentsExcept(int activeParent)
    {
        for (int i = 0; i < imageParents.Count; i++)
        {

            if(i != activeParent)
            {
                imageParents[i].gameObject.SetActive(false); 
            }
            else
            {
                imageParents[i].gameObject.SetActive(true);
            }

        }
    }

}
