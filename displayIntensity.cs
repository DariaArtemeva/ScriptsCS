using UnityEngine;
using UnityEngine.UI;

public class displayIntensity : MonoBehaviour
{
    public Text VoltageText;
    public Text ResistanceText;
    public LightControl lightControl;

    void Update()
    {
        int currentResistance = lightControl.GetResistance();
        ResistanceText.text = "Resistance: " + currentResistance.ToString() + " Ohm";
        VoltageText.text = "Voltage: 4.5V";
    }
}

