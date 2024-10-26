using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireCollision : MonoBehaviour
{
    

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider[] cols = GetComponentsInChildren<Collider>();
        foreach (Collider col in cols)
        {
            if (!col.isTrigger)
            {
                col.enabled = false;
                col.enabled = true;
            }
        }
    }

}
