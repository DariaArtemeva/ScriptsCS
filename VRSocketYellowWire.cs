using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRSocketYellowWire : MonoBehaviour
{
    public Transform attachmentPoint;

    public WireManager wireManager; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("YellowWire"))
        {
            AttachObject(other.gameObject);
            wireManager.SetWireState("YellowWire", true); 
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
