using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class ImageTargetController : MonoBehaviour
{
    public string videoURL;

    public GameObject vrVideoBtn;  //Button cliclking on which will open the VR video 

    public Text rotationVal; 

    // Start is called before the first frame update
    void Start()
    {       
        StartCoroutine("EnableVRButtonAfterDelay"); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator EnableVRButtonAfterDelay()
    {
        //Enable that button after a delay of 6 seconds
        yield return new WaitForSeconds(6); 
        vrVideoBtn.SetActive(true); 
    }

    public void PlayVideoInVR()
    {
        Application.OpenURL(videoURL); 
    }

    /// <summary>
    /// To check which a new Image, it loads the scene again to test with some other Image Target
    /// </summary>
    public void TryNewImage()
    {
        SceneManager.LoadScene(0); 

    }

    ///<summary>
    ///The below methods are for testing only
    ///</summary>
    public void RotateGameObjectX()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("ImageTarget");

        //Rotate along X-axis
        obj.transform.Rotate(90f, 0f, 0f, Space.Self);

        rotationVal.text = obj.transform.rotation.eulerAngles.ToString();

        Debug.Log("Rotation Values are: " + obj.transform.localRotation.eulerAngles); 
    }

    public void RotateGameObjectY()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("ImageTarget");

        //Rotate along Y-axis
        obj.transform.Rotate(0f, 90f, 0f, Space.Self);

        rotationVal.text = obj.transform.localRotation.eulerAngles.ToString();

        Debug.Log("Rotation Values are: " + obj.transform.rotation.eulerAngles);
    }

    public void RotateGameObjectZ()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("ImageTarget");

        //Rotate along Z-axis
        obj.transform.Rotate(0f, 0f, 90f, Space.Self);

        rotationVal.text = obj.transform.localRotation.eulerAngles.ToString();

        Debug.Log("Rotation Values are: " + obj.transform.rotation.eulerAngles);
    }

}
