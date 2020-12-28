using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSample : MonoBehaviour {
	public Image cbody;
	public Image cface;
	public Image chair;
	public Image ckit;
	public Sprite[] body;
	public Sprite[] face;
	public Sprite[] hair;
	public Sprite[] kit;

	// Use this for initialization
	void Start () {
		RandomizeCharacter();
	}
	private void OnEnable()
	{
		EventManager.OnOrderGenerated.AddListener(RandomizeCharacter);
	}
	private void OnDisable()
	{
		EventManager.OnOrderGenerated.RemoveListener(RandomizeCharacter);
	}
	private void RandomizeCharacter(){
		cbody.sprite = body[Random.Range(0,body.Length)];
		cface.sprite = face[Random.Range(0,face.Length)];
		chair.sprite = hair[Random.Range(0,hair.Length)];
		ckit.sprite = kit[Random.Range(0,kit.Length)];
	}

}
