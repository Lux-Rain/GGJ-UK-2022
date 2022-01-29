using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera camOne;
    public Camera camTwo;
   // public KeyCode cameraKey;
    //public KeyCode screenshotKey;
    public bool cameraActivated = true;
    public bool switchOccuring = false;

    private void Start()
    {
        camOne.gameObject.SetActive(true);
        camTwo.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C) && !switchOccuring)
        {
            Switch();
        }

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

}
