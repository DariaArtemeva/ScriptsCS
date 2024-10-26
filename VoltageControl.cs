using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;    

public class VoltageControl : MonoBehaviour
{
    public Text VoltageText;
    public Text ResistanceText;
    public LightIntensivityController lightControl;

    void Update()
    {
        float currentVoltage = lightControl.GetCurrentVoltage();
        ResistanceText.text = "Resistance: 1000 Ohm";
        VoltageText.text = "Voltage:" + currentVoltage.ToString() + "V";
    }
}
