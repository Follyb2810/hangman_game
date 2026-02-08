using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     string myName ="follyb";
     Debug.Log(myName.Substring(0,1));   
     Debug.Log(myName.Substring(3,2));   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
