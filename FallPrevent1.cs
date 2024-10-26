using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPrevent1 : MonoBehaviour
{
   
    public Vector3 resetPosition;

    void Start() {
 
        if (resetPosition == Vector3.zero) {
            resetPosition = new Vector3(2, 2, 10); 
        }
    }

  
    private void OnTriggerEnter(Collider other) {
      
        if (other.CompareTag("FallingObject") || other.CompareTag("RightBattery")) {
        
            other.transform.position = resetPosition;
        }
    }
}
