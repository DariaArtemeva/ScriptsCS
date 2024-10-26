using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEDControl : MonoBehaviour
{
    public float Bright = 2f;
    public float Medium = 1f;
    public float Low = 0.5f;
    public float zero = 0f;

  
    public void SetLightIntensityByLED(string LEDtype, Light ledLight)
    {
        float intensity = zero; 

        switch (LEDtype)
        {
            case "GreenLED":
                intensity = Low;
                break;
            case "BlueLED":
                intensity = Low;
                break;
            case "RedLED":
                intensity = Bright;
                break;
            case "YellowLED":
                intensity = Medium;
                break;
            default:
                Debug.LogError("Неизвестный тип LED: " + LEDtype);
                return;
        }

        if (ledLight != null)
        {
            ledLight.intensity = intensity;
        }
    }
}
