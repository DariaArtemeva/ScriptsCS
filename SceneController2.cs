using UnityEngine;

public class SceneController2 : MonoBehaviour
{
    public DialogueSystem ds;
    public static SceneController2 Instance; 

    public bool isSwitchTurned = false; 
    public bool isRightBattery = false; 
    public bool isWire1Connected = false; 
    public bool isWire2Connected = false;

    public Light pointLight1;
    public Light pointLight2;
    public Light pointLight3;
    public GameObject teleportNext;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CheckConditions()
    {
        if (isSwitchTurned && isRightBattery && isWire1Connected && isWire2Connected)
        {
            
            TurnOnTheLight();
            ds.PlayDialogue(1);
        }
    }

    void TurnOnTheLight()
    {

        if (pointLight1 != null && pointLight2 != null && pointLight3 != null ) 
        {
            pointLight1.enabled = true; 
            pointLight2.enabled = true; 
            pointLight3.enabled = true; 
    
        }
        teleportNext.SetActive(true);
    }
}
