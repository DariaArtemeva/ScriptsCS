using UnityEngine;

public class LightControl : MonoBehaviour
{
    public Light targetLight;


    public float highResistanceIntensity = 0f;
    public float mediumResistanceIntensity = 1f;
    public float lowResistanceIntensity = 2f;
    int resistance;

    private void Start()
    {

        if (targetLight != null)
        {
            targetLight.intensity = 0f;
        }
    }
   
   
    public void SetLightIntensityByResistance(string resistanceType)
    {
        float intensity = 0f;

        switch (resistanceType)
        {
            case "Resistor1M":
                intensity = highResistanceIntensity;
                resistance = 1000000;
                break;
            case "Resistor100K":
                intensity = mediumResistanceIntensity;
                resistance = 100000;
                break;
            case "Resistor1":
                intensity = lowResistanceIntensity;
                resistance = 1000;
                break;
            default:
                Debug.LogError("unknown: " + resistanceType);
                break;
        }

        if (targetLight != null)
        {
            targetLight.intensity = intensity;
        }
    }
    public int GetResistance()
    {
        return resistance;
    }
}
