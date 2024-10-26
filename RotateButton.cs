using UnityEngine;
using UnityEngine.Events;

namespace Valve.VR.InteractionSystem
{
    [RequireComponent(typeof(Interactable))]
    public class RotateButton : MonoBehaviour
    {
        public Transform rotatingPart; 
        public Vector3 rotationAngle = new Vector3(0, 0, 30); 
        public float rotationSpeed = 2.0f; 

        private Quaternion startRotation; 
        private Quaternion endRotation; 
        private Quaternion targetRotation; 

        private bool isRotating = false; 
        private bool interactionCompleted = false; 

        private void Start()
        {
            startRotation = rotatingPart.localRotation;
            endRotation = Quaternion.Euler(rotationAngle) * startRotation;
        }

        private void Update()
        {
            if (isRotating)
            {
                
                rotatingPart.localRotation = Quaternion.Lerp(rotatingPart.localRotation, targetRotation, Time.deltaTime * rotationSpeed);

                if (Quaternion.Angle(rotatingPart.localRotation, targetRotation) < 0.1f)
                {
                    rotatingPart.localRotation = targetRotation; 
                    isRotating = false; 
                    interactionCompleted = true; 
                }
            }
        }

        private void HandHoverUpdate(Hand hand)
        {
            if (!isRotating && !interactionCompleted)
            {
               
                targetRotation = rotatingPart.localRotation == startRotation ? endRotation : startRotation;
                isRotating = true;
                SceneController2.Instance.isSwitchTurned = true; 
                SceneController2.Instance.CheckConditions();
            }
        }
    }
}
