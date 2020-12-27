using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseYourself : MonoBehaviour
{
    public GameObject particles;
    public void CloseYourSelfM()
    {
        gameObject.SetActive(false);
    }
    public void CloseParticleToo()
    {
        particles.SetActive(false);
    }
}
