using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchCamera : MonoBehaviour
{
    public Camera camOne;
    public Camera camTwo;
    public bool cameraActivated = false;
    public bool switchOccuring = false;
    public Controls inputActions;

    

    private void Awake()
    {
        inputActions = new Controls();
        inputActions.Normal.EnableCamera.started += ctx => Switch();
        // inputActions.Normal.TakeScreenshot.performed += ctx => Screenshot();
        inputActions.Camera.Capture.performed += ctx => Screenshot();
        camOne.gameObject.SetActive(true);
        camTwo.gameObject.SetActive(false);

    }

    void OnEnable()
    { inputActions.Normal.Enable();
        inputActions.Camera.Enable();
    }

    void OnDisable()
    { inputActions.Normal.Disable();
        inputActions.Camera.Disable();
    }


    void Switch()
    {
        switchOccuring = true;
        if (cameraActivated)
        {
            camOne.gameObject.SetActive(false);
            camTwo.gameObject.SetActive(true);
            Debug.Log("switch camera 1");
        }
        else
        {
            camOne.gameObject.SetActive(true);
            camTwo.gameObject.SetActive(false);
            Debug.Log("switch camera 2");
        }

        cameraActivated = !cameraActivated;
        switchOccuring = false;
    }

    void Screenshot()
    {

        string path = "Assets/Screenshots/";
        GameObject currentLocation = this.GetComponentInParent<Location>().currentLocation; //room where the player is at the moment

        if (!cameraActivated) {
            ScreenCapture.CaptureScreenshot(path + currentLocation.name + ".png"); 
        
        }
    }

}
