using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySocket : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            gameObject.SetActive(false);

        }
    }
}
