using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyToys : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Item item = other.GetComponent<Item>();

        if(item != null)
        {
            Destroy(other.gameObject);
        }
    }
}
