using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRSocketLED : MonoBehaviour
{
    public Transform attachmentPoint;
    public LEDControl LEDControl;
    public DialogueSystem dialogueSystem;

    private bool dialoguePlayed = false;

    public bool isOccupied = false;  

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("GreenLED") || other.CompareTag("BlueLED") || other.CompareTag("RedLED") || other.CompareTag("YellowLED")) && !isOccupied) 
        {
            AttachObject(other.gameObject);

            if (!dialoguePlayed)
            {
                dialogueSystem.PlayDialogue(4);
                dialoguePlayed = true;
            }

            Light ledLight = other.gameObject.GetComponentInChildren<Light>();

            if (ledLight != null)
            {
                switch (other.tag) 
                {
                    case "GreenLED":
                        LEDControl.SetLightIntensityByLED("GreenLED", ledLight);
                        break;
                    case "BlueLED":
                        LEDControl.SetLightIntensityByLED("BlueLED", ledLight);
                        break;
                    case "RedLED":
                        LEDControl.SetLightIntensityByLED("RedLED", ledLight);
                        break;
                    case "YellowLED":
                        LEDControl.SetLightIntensityByLED("YellowLED", ledLight);
                        break;
                }
            }
            else
            {
                Debug.LogError("Light component not found on " + other.gameObject.name);
            }

            isOccupied = true;  
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GreenLED") || other.CompareTag("BlueLED") || other.CompareTag("RedLED") || other.CompareTag("YellowLED"))
        {
            DetachObject(other.gameObject);
            dialogueSystem.UnlockTeleportPoint(2);

            Light ledLight = other.gameObject.GetComponentInChildren<Light>();
            if (ledLight != null)
            {
                ledLight.intensity = 0f;
            }

            isOccupied = false; 
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
  //          rb.isKinematic = false;
 //           rb.useGravity = true;
        }
    }
}
