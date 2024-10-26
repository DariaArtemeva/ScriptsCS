using UnityEngine;

public class VRSocketResistor : MonoBehaviour
{
    public Transform attachmentPoint;
    public LightIntensivityController lightController;
    public int decreaseIntensityStep = 3;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called with: " + other.name);
        if (other.CompareTag("Resistor"))
        {
            AttachObject(other.gameObject);
            lightController.UpdateObjectCount(-decreaseIntensityStep); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit called with: " + other.name);
        if (other.CompareTag("Resistor"))
        {
            DetachObject(other.gameObject);
            lightController.UpdateObjectCount(decreaseIntensityStep); 
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
    private void DetachObject(GameObject obj)
    {


        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
        }

    }
}
