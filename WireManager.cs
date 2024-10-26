using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WireManager : MonoBehaviour
{

    private Dictionary<string, bool> wiresConnected = new Dictionary<string, bool>();

   
    public GameObject lightBulb;

    private void Start()
    {
    
        wiresConnected["GreenWire"] = false;
        wiresConnected["RedWire"] = false;
        wiresConnected["BlueWire"] = false;
        wiresConnected["YellowWire"] = false;
        
    }

  
    public void SetWireState(string wireTag, bool isConnected)
    {
        if (wiresConnected.ContainsKey(wireTag))
        {
            
            wiresConnected[wireTag] = isConnected;
            CheckAllWiresConnected();
        }
    }

 
    private void CheckAllWiresConnected()
         
    {
        Debug.Log("Checking...");
        foreach (var wire in wiresConnected)
        {
            if (!wire.Value) return; 
        }
        Light lightComponent = lightBulb.GetComponent<Light>();
        lightComponent.enabled = true;
        Debug.Log("Light!");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Finish");
    }
}
