using UnityEngine;

public class CameraShake : MonoBehaviour
{
    
    public float shakeDuration = 0.5f; 
    public float shakeMagnitude = 0.1f; 

    private bool isShaking = false;
    private Vector3 originalPosition;

    void Start()
    {
        isShaking = true;
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        if (isShaking)
        {
           
            Vector3 shakeAmount = Random.insideUnitSphere * shakeMagnitude;

         
            transform.localPosition = originalPosition + shakeAmount;

            shakeDuration -= Time.deltaTime;

          
            if (shakeDuration <= 0)
            {
                isShaking = false;
                transform.localPosition = originalPosition;
            }
        }
    }

 
    public void StartShake()
    {
        isShaking = true;
        shakeDuration = 0.5f; 
    }
}
