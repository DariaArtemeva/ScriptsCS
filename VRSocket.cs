using UnityEngine;

public class VRSocket : MonoBehaviour
{

    public Transform attachmentPoint1;
    public Transform attachmentPoint2;
    public Transform attachmentPoint3;
    public LightIntensivityController lightController;
    public DialogueSystem dialogueSystem;

    private bool dialoguePlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        dialogueSystem.UnlockTeleportPoint(3);

        if (!dialoguePlayed)
        {
            dialogueSystem.PlayDialogue(6); 
            dialoguePlayed = true;
        }

        switch (other.tag)
        {
            case "Battery1":
                AttachObject(other.gameObject, attachmentPoint1);
                break;
            case "Battery2":
                AttachObject(other.gameObject, attachmentPoint2);
                break;
            case "Battery3":
                AttachObject(other.gameObject, attachmentPoint3);
                break;
        }

        lightController.UpdateObjectCount(1);
    }

    private void OnTriggerExit(Collider other)
    {
        DetachObject(other.gameObject);
        lightController.UpdateObjectCount(-1);
    }

    private void AttachObject(GameObject obj, Transform attachmentPoint)
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
//            rb.isKinematic = false;
        }
    }
}
