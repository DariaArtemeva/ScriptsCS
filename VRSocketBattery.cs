
using UnityEngine;



public class VRSocketBattery : MonoBehaviour
{
    public Transform attachmentPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RightBattery"))
        {
            AttachObject(other.gameObject);
            SceneController2.Instance.isRightBattery = true; 
            SceneController2.Instance.CheckConditions();
    
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("RightBattery"))
    //    {
    //        DetachObject(other.gameObject);
         
    //    }
    //}

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
    //        rb.isKinematic = false;
        }

    }

}
