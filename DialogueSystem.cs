using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class DialogueSystem : MonoBehaviour {
    public Text dialogueText;
    public string[] sentences;
    public AudioClip[] audioClips;
    private AudioSource audioSource;
    private int index = 0;
    public float typingSpeed = 0.02f;
    public delegate void DialogueEndAction();
    public event DialogueEndAction OnDialogueEnd;

    public TeleportPoint[] teleportPoints;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        PlayDialogue(0);
        LockAllTeleportPoints();

  
    }


    void LockAllTeleportPoints() {
        foreach (var point in teleportPoints) {
            point.locked = true;
            point.UpdateVisuals();
        }
    }

    public void UnlockTeleportPoint(int pointIndex) {
        if (pointIndex < teleportPoints.Length) {
            teleportPoints[pointIndex].locked = false;
            teleportPoints[pointIndex].UpdateVisuals();
        }
    }
    IEnumerator TypeSentence(string sentence) {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        audioSource.clip = audioClips[index];
        audioSource.Play();

        yield return new WaitUntil(() => !audioSource.isPlaying); 

       
        if (index == 0) { 
            UnlockTeleportPoint(0); 
        }
    }

    public void PlayDialogue(int dialogueIndex) {
        if (dialogueIndex >= 0 && dialogueIndex < sentences.Length) {
            index = dialogueIndex;
            dialogueText.text = ""; 
            StartCoroutine(TypeSentence(sentences[index])); 
        }
    }

    void HandleDialogueEnd() {
      
        Debug.Log("Dialogue has ended.");

    }
}
