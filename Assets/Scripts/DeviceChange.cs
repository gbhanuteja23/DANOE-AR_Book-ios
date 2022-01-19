using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.UI;

public class DeviceChange : MonoBehaviour
{

    public GameObject session;
    public GameObject cameraSession;
    public Text txt;
    // Start is called before the first frame update
    void Start()
    {
        txt.text = "ARSCENE" + XRSettings.loadedDeviceName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        txt.text = "ARSCENE 1" + XRSettings.loadedDeviceName;
        session.SetActive(false);
        cameraSession.SetActive(false);
        XRSettings.LoadDeviceByName("Cardboard");
        SceneManager.LoadScene("HelloVR");
        txt.text = "ARSCENE 2" + XRSettings.loadedDeviceName;
    }

}
