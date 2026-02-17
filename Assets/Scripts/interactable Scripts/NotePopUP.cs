using UnityEngine;

public class NotePopUp : MonoBehaviour
{
    public Transform holdPoint;   // Camera/HoldPoint
    public SimpleFPSController playerController; // drag Player here

    Vector3 startingPosition;
    Quaternion startRotation;
    Transform startParent;

    bool isOpen;

    void Start()
    {
        startingPosition = transform.position;
        startRotation = transform.rotation;
        startParent = transform.parent;
    }

    void Update()
    {
        if (isOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseNote();
        }
    }

    public void PopUpToFace()
    {
        isOpen = true;

        // disable movement
        playerController.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // move note to camera
        transform.SetParent(holdPoint);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    void CloseNote()
    {
        isOpen = false;

        // return to original position
        transform.SetParent(startParent);
        transform.position = startingPosition;
        transform.rotation = startRotation;

        // re-enable movement
        playerController.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
