using UnityEngine;

public class VRSocketResistor1 : MonoBehaviour {
    public DialogueSystem dialogueSystem;
    public LightControl lightControl;
    public Transform attachmentPoint;

    private bool dialoguePlayed = false;
    private bool isOccupied = false;  

    private void OnTriggerEnter(Collider other) {
        if ((other.CompareTag("Resistor1") || other.CompareTag("Resistor100K") || other.CompareTag("Resistor1M")) && !isOccupied) {
            if (!dialoguePlayed) {
                dialogueSystem.PlayDialogue(2);
                dialoguePlayed = true;
            }

            AttachObject(other.gameObject);

            if (other.CompareTag("Resistor1")) {
                lightControl.SetLightIntensityByResistance("Resistor1");
            } else if (other.CompareTag("Resistor100K")) {
                lightControl.SetLightIntensityByResistance("Resistor100K");
            } else if (other.CompareTag("Resistor1M")) {
                lightControl.SetLightIntensityByResistance("Resistor1M");
            }

            isOccupied = true;  
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Resistor1") || other.CompareTag("Resistor100K") || other.CompareTag("Resistor1M")) {
            dialogueSystem.UnlockTeleportPoint(1);
            DetachObject(other.gameObject);
            lightControl.SetLightIntensityByResistance("Resistor1M");

            isOccupied = false;  
        }
    }

    private void AttachObject(GameObject obj) {
        obj.transform.position = attachmentPoint.position;
        obj.transform.rotation = attachmentPoint.rotation;
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null) {
            rb.isKinematic = true;
        }
    }

    private void DetachObject(GameObject obj) {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null) {
 //           rb.isKinematic = false;
 //           rb.useGravity = true;
        }
    }
}
