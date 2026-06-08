using UnityEngine;

public class PlayerInteracting : MonoBehaviour
{
    private IInteractable currentInteractable;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) &&
            currentInteractable != null)
        {
            print("je hebt op e gedrukt");
            currentInteractable.Interact(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IInteractable interactable =
            other.GetComponent<IInteractable>();

        if (interactable != null)
        {
            currentInteractable = interactable;

            Debug.Log(interactable.GetInteractionPrompt());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        IInteractable interactable =
            other.GetComponent<IInteractable>();

        if (interactable != null &&
            interactable == currentInteractable)
        {
            currentInteractable = null;
        }
    }
}
