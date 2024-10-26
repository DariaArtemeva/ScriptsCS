using UnityEngine;

public class TriggerDialogue : MonoBehaviour {
    public DialogueSystem dialogueSystem;
    public int dialogueIndex1 = 1;
    public Transform sparky; 
    public Vector3 sparkyPosition;
    public Vector3 sparkyRotation;




    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            dialogueSystem.PlayDialogue(dialogueIndex1);
            sparky.position = sparkyPosition;
            sparky.rotation = Quaternion.Euler(sparkyRotation);
            gameObject.SetActive(false); 
            
        }
    }
}
