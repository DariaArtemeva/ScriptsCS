using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineConnector1 : MonoBehaviour
{
    public GameObject[] _objs;
    private LineRenderer line;
    void Start()
    {
        line = this.gameObject.GetComponent<LineRenderer>();
        line.positionCount = _objs.Length;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _objs.Length; i++ ) 
        {
            line.SetPosition(i, _objs[i].transform.position);
        }
    }
}
