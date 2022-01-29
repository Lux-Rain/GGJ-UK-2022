using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

public class Polaroid : MonoBehaviour
{
    private bool isEnable;

    [SerializeField]
    private Camera cam;
    [SerializeField]
    private Camera renderCam;

    [SerializeField]
    private Texture2DCollection pictures;
    [SerializeField]
    private AK.Wwise.Event capture;
    [SerializeField]
    private AK.Wwise.Event captureSuccess;

    public void EnableCam()
    {
        cam.enabled = true;
        isEnable = true;
    }

    public void DisableCam()
    {
        cam.enabled = false;
        isEnable = false;
    }

    public void Capture()
    {
        if(!isEnable) return;
        // The Render Texture in RenderTexture.active is the one
        // that will be read by ReadPixels.
        RenderTexture render = new RenderTexture(512, 512, 24);
        var currentRT = RenderTexture.active;
        renderCam.targetTexture = render;
        RenderTexture.active = renderCam.targetTexture;

        // Render the camera's view.
        renderCam.Render();
        // Make a new texture and read the active Render Texture into it.
        Texture2D image = new Texture2D(renderCam.targetTexture.width, renderCam.targetTexture.height);
        image.ReadPixels(new Rect(0, 0, renderCam.targetTexture.width, renderCam.targetTexture.height), 0, 0);
        image.Apply();

        // Replace the original active Render Texture.
        RenderTexture.active = currentRT;
        image.name = $"Picture {pictures.Count}";
        pictures.Add(image);
        capture.Post(gameObject);

    }
}
