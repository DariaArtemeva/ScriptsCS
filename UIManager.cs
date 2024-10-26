using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject volumeSliderPanel;
    public GameObject[] otherButtons; 


    public void ToggleOptions()
    {
    
        volumeSliderPanel.SetActive(!volumeSliderPanel.activeSelf);

       
        foreach (var button in otherButtons)
        {
            button.SetActive(!button.activeSelf);
        }
    }
    public void BackButtonPressed()
    {
     
        volumeSliderPanel.SetActive(false);

   
        foreach (var button in otherButtons)
        {
            button.SetActive(true);
        }
    }

    void Start()
    {
     
        volumeSliderPanel.SetActive(false);
    }
}
