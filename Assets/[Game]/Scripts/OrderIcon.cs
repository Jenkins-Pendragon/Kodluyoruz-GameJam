using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using DG.Tweening;

public class OrderIcon : MonoBehaviour
{

    private List<Image> OrderedImage = new List<Image>();
    public List<Points> imagePoints;
   


    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            OrderedImage.Add(imagePoints[i].points[i]);
        }
       




        for (int i = 0; i < LevelManager.Instance.orderItems.Count; i++)
        {
            
            
            OrderedImage[i].sprite = LevelManager.Instance.orderItems.Values.ElementAt(i).toyIcon;
            //imagePoints[i].points[i].sprite = OrderedImage[i].sprite;
            OrderedImage[i].DOFade(0, 0);
            OrderedImage[i].DOFade(1, 2);
        }

    }


    [System.Serializable]
    public class Points
    {
        public Image[] points;
    }
}
