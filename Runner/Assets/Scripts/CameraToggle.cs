using UnityEngine;
using System.Collections;

public class CameraToggle : MonoBehaviour
{

    public string FirstCameraName = "MainCamera";
    public string SecondCameraName = "SideCamera";

    private Camera firstCamera;
    private Camera secondCamera;

    private bool IsFirstEnabled = true;

    void Start()
    {
        foreach (var cam in Camera.allCameras)
        {
            if (cam.gameObject.name == FirstCameraName)
                firstCamera = cam;
            else if (cam.gameObject.name == SecondCameraName)
                secondCamera = cam;
        }

        if (firstCamera != null && secondCamera != null)
        {
            firstCamera.gameObject.SetActive(true);
            secondCamera.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (firstCamera != null && secondCamera != null)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (IsFirstEnabled)
                {
                    firstCamera.enabled = false;
                    secondCamera.enabled = true;

                    firstCamera.gameObject.SetActive(false);
                    secondCamera.gameObject.SetActive(true);
                }
                else
                {
                    firstCamera.enabled = true;
                    secondCamera.enabled = false;

                    firstCamera.gameObject.SetActive(true);
                    secondCamera.gameObject.SetActive(false);
                }

                IsFirstEnabled = !IsFirstEnabled;
            }
        }
    }
}
