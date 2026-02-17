using UnityEngine;

public class KeypadZoom : MonoBehaviour
{
    public Transform zoomPoint;                
    public Transform playerCamera;              
    public SimpleFPSController playerController; 

    Vector3 camPos;
    Quaternion camRot;
    bool zoomed;

    void Update()
    {
        if (zoomed && Input.GetKeyDown(KeyCode.Escape))
            ExitZoom();
    }

    public void EnterZoom()
    {
        if (zoomed) return;
        zoomed = true;

        camPos = playerCamera.position;
        camRot = playerCamera.rotation;

        playerController.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        playerCamera.position = zoomPoint.position;
        playerCamera.rotation = zoomPoint.rotation;
        Debug.Log(playerCamera + " " + zoomPoint + " " + playerController);

    }

    public void ExitZoom()
    {
        if (!zoomed) return;
        zoomed = false;

        playerCamera.position = camPos;
        playerCamera.rotation = camRot;

        playerController.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
