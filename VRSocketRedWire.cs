using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRSocketRedWire : MonoBehaviour
{
    public Transform attachmentPoint;

    public WireManager wireManager; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedWire"))
        {
            AttachObject(other.gameObject);
            wireManager.SetWireState("RedWire", true); 
        }
    }

    private void AttachObject(GameObject obj)
    {
        obj.transform.position = attachmentPoint.position;
        obj.transform.rotation = attachmentPoint.rotation;

        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }

    }
   
}
