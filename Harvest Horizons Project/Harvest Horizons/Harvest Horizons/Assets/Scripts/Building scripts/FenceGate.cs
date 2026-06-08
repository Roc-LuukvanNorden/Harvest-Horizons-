using UnityEngine;

public class FenceGate : MonoBehaviour, IInteractable
{
    [SerializeField] private float openAngle = 90f;
    [SerializeField] private float rotationSpeed = 5f;

    [SerializeField] private Collider2D blockingCollider;

    private bool isOpen;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        closedRotation = transform.rotation;

        openRotation = Quaternion.Euler(
            0f,
            0f,
            transform.eulerAngles.z + openAngle
        );
    }

    void Update()
    {
        Quaternion targetRotation =
            isOpen ? openRotation : closedRotation;

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetRotation,
            Time.deltaTime * rotationSpeed
        );
    }

    public void Interact(GameObject interactor)
    {
        isOpen = !isOpen;

      
        if (blockingCollider != null)
        {
            blockingCollider.enabled = !isOpen;
        }
    }

    public string GetInteractionPrompt()
    {
        return isOpen ? "Close" : "Open";
    }
}
