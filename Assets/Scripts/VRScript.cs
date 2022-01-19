using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        XRSettings.LoadDeviceByName("Cardboard");
        Debug.Log("IN VR SCENE " + XRSettings.loadedDeviceName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
