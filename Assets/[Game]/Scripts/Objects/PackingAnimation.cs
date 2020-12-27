using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PackingAnimation : MonoBehaviour
{
    public Transform lidDefaultTransform;
    public GameObject lid;
    public float tweenDelay = 0.2f;

    private void OnEnable()
    {
        EventManager.OnItemsPacked.AddListener(PlayPackAnimation);
    }

    private void OnDisable()
    {
        EventManager.OnItemsPacked.RemoveListener(PlayPackAnimation);
    }

    private void PlayPackAnimation() 
    {
        lid.transform.DOMove(lidDefaultTransform.position, tweenDelay);
        lid.transform.DORotate(Vector3.zero, tweenDelay).OnComplete(()=> 
        {
            EventManager.OnOrderCompleted.Invoke();
        });
    }
}
