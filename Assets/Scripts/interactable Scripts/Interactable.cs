using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

    Outline outline;
    public string message;

    public UnityEvent onInteract;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       outline = GetComponent<Outline>();
       disableOutline();
    }

    public void Interact()
    {
        onInteract.Invoke();
    }
    public void enableOutline()
    {
        outline.enabled = true;
    }

    public void disableOutline()
    {
        outline.enabled = false;
    }
    
}
