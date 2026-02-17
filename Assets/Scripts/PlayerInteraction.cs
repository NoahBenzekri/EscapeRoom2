using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactRange = 3f;
    Interactable currentInteractable;

    void Update()
    {
        CheckForInteractable();

        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
            currentInteractable.Interact();
    }

    void CheckForInteractable()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
        {
            // IMPORTANT: works even if the collider is on a child mesh
            Interactable newInteractable = hit.collider.GetComponentInParent<Interactable>();

            if (newInteractable != null && newInteractable.enabled)
            {
                if (currentInteractable != null && newInteractable != currentInteractable)
                    currentInteractable.disableOutline();

                SetNewCurrentInteractable(newInteractable);
                return;
            }
        }

        DisableCurrentInteractable();
    }

    void SetNewCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.enableOutline();
    }

    void DisableCurrentInteractable()
    {
        if (currentInteractable != null)
        {
            currentInteractable.disableOutline();
            currentInteractable = null;
        }
    }
}
