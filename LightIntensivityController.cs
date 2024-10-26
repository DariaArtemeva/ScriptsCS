using UnityEngine;
using System.Collections.Generic;

public class LightIntensivityController : MonoBehaviour
{
    public List<Light> targetLights;
    public float intensityStep = 5.0f;
    private int totalObjectCount = 0;
    private float currentIntensity = 0f;
    private float currentVoltage = 0f;
    public DialogueSystem dialogueSystem;

    public void UpdateObjectCount(int change)
    {
        totalObjectCount += change;
        UpdateLightIntensity();
        if (totalObjectCount == 3)
        {
            dialogueSystem.PlayDialogue(7);
            dialogueSystem.UnlockTeleportPoint(3);
        }
    }

    private void UpdateLightIntensity()
    {
        currentIntensity = Mathf.Max(0, intensityStep * totalObjectCount);
        currentVoltage = Mathf.Max(0, 1.5f * totalObjectCount);
        foreach (Light light in targetLights)
        {
            if (light != null)
            {
                light.intensity = currentIntensity;
            }
        }
    }
    public float GetCurrentIntensity()
    {
        return currentIntensity;
    }
    public float GetCurrentVoltage()
    {
        return currentVoltage;
    }
}
