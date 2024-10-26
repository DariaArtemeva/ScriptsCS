using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRSocketGreenWire : MonoBehaviour
{
    public Transform attachmentPoint;
    public WireManager wireManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GreenWire"))
        {
            AttachObject(other.gameObject);
            wireManager.SetWireState("GreenWire", true);

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
