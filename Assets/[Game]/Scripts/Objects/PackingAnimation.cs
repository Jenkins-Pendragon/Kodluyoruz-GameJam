using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PackingAnimation : MonoBehaviour
{
    public Transform lidDefaultTransform;
    public Transform jumpPoint;    
    public GameObject lid;
    public float tweenDelay = 0.2f;
    private Vector3 boxPos;
    private Vector3 lidPos;
    private Vector3 lidRotation;

    private void OnEnable()
    {
        EventManager.OnItemsPacked.AddListener(PlayPackAnimation);
    }

    private void OnDisable()
    {
        EventManager.OnItemsPacked.RemoveListener(PlayPackAnimation);
    }

    private void Start()
    {
        boxPos = gameObject.transform.position;
        lidPos = lid.transform.position;
        lidRotation.x = lid.transform.rotation.x;
        lidRotation.y = lid.transform.rotation.y;
        lidRotation.z = lid.transform.rotation.z;
    }

    private void PlayPackAnimation()
    {
        lid.transform.DOMove(lidDefaultTransform.position, tweenDelay);
        lid.transform.DORotate(Vector3.zero, tweenDelay).OnComplete(() => {

            gameObject.transform.DOJump(jumpPoint.position, 1.5f, 1, 0.5f);
            gameObject.transform.DORotate(new Vector3(45, 0, 0), 0.5f);
            Sequence seq = DOTween.Sequence();
            seq.Append(gameObject.transform.DOScale(Vector3.one * 4f, 0.25f));
            seq.Append(gameObject.transform.DOScale(Vector3.one * 0f, 0.25f)).OnComplete(()=> 
            {
                gameObject.transform.position = boxPos;
                gameObject.transform.DOScale(2.75f, tweenDelay).OnComplete(() =>
                {
                    lid.transform.DOMove(lidPos, tweenDelay);
                    lid.transform.DORotate(lidRotation, tweenDelay);
                });
            });
        });

    }
}
